using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.S3;
using Amazon.S3.Model;
using Aula.AWS.Application.DTOs;
using Aula.AWS.Lib.Interfaces;
using Aula.AWS.Lib.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula.AWS.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _repositorio;
        private readonly AmazonRekognitionClient _rekognitionClient;
        private readonly IAmazonS3 _amazonS3;
        public static List<Usuario>ListaUsuarios {get; set;}=new List<Usuario>();
        private static readonly List<string> _extensoesImagem = new List<string>(){"imageinjpeg", "imageinpng"};


        public UsuarioController(IUsuarioRepositorio repositorio, IAmazonS3 amazonS3, AmazonRekognitionClient rekognitionClient)
        {
            _repositorio = repositorio; 
            _amazonS3 = amazonS3;
            _rekognitionClient = rekognitionClient;
        }

        [HttpGet]
        public async Task<IActionResult>ListarTodos()
        {
            return Ok (await _repositorio.PesquisaAsync());
        }
        [HttpDelete]
        public async Task<IActionResult>Deletar(int id)
        {
            await _repositorio.DeletarAsync(id);
            return Ok("Usuario foi Deletado.");
        }
        [HttpPost]
        public async Task<IActionResult>Adicionar(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario(usuarioDTO.id, usuarioDTO.Nome, usuarioDTO.Cpf, usuarioDTO.DataNascimento, usuarioDTO.Email, usuarioDTO.Senha, usuarioDTO.UrlImagemCadastro, usuarioDTO.DataCriacao);

            await _repositorio.AddAsync(usuario);
            return Ok(usuario);
            
        }
        [HttpPost("Cadastrar Imagem")]
        public async Task<IActionResult> CadastrarImagem(int id, IFormFile imagem)
        {

            try{ //chamada do metodo na application //retorna Ok com o resultado

            }
            catch(SystemException)
            { //return badrequest
                throw;
            }

            var nomeArquivo = await SalvarS3(imagem);
            var imagemValida = await ValidarImagem(nomeArquivo);
            if(imagemValida)
            {
                return Ok();
            }
            else
            {
                _amazonS3.DeleteObjectAsync("imagem-aulas", nomeArquivo);
                return BadRequest();
            }
        }
        
        private async Task<string> SalvarS3(IFormFile image)
        {
            if(!_extensoesImagem.Contains(image.ContentType))
            {
                throw new Exception("Tipo de imagem invalida");
            }
            using (var streamDaImagem = new MemoryStream())
            {  
                await image.CopyToAsync(streamDaImagem);  

                var request = new PutObjectRequest();
                request.Key = "reconhecimento" + image.FileName;
                request.BucketName = "imagem-Aulas";
                request.InputStream = streamDaImagem;
                
                var resposta = await _amazonS3.PutObjectAsync(request);
                return request.Key;
            }
        }
        
        private async Task<bool> ValidarImagem(string nomeArquivo)
        {
            var entrada = new DetectFacesRequest();
            var imagem = new Image();

            var s3Object = new Amazon.Rekognition.Model.S3Object(){
                Bucket = "reconhecimento-api",
                Name = nomeArquivo
            }; 

            imagem.S3Object = s3Object;
            entrada.Image = imagem;
            entrada.Attributes = new List<string>(){"ALL"};

            var resposta = await _rekognitionClient.DetectFacesAsync(entrada);

            if(resposta.FaceDetails.Count == 1 && resposta.FaceDetails.First().Eyeglasses.Value == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPut]
        public async Task<IActionResult>AlterandoSenha(int  id, string senha)
        {
            await  _repositorio.MudancaSenha(id, senha);
            return Ok("Alteração de senha concluida.");
        }
        
    }
}