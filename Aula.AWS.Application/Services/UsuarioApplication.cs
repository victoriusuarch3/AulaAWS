using Aula.AWS.Application.DTOs;
using Aula.AWS.Lib.Interfaces;
using Aula.AWS.Lib.Models;
using Aula.AWS.Lib.Repositorio;
using Microsoft.AspNetCore.Http;

namespace Aula.AWS.Application.Services
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUsuarioRepositorio _repositorio;
        public static List<Usuario> ListaUsuarios {get; set;} = new List<Usuario>();
        public readonly List<string> _imageFormats = new List<string>() {
            "jpeg", "png"
        };
        private readonly IServiceAWS _amazonServices;

        public UsuarioApplication(UsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
            _amazonServices = amazonServices;
        }
        public async Task<Guid> AddUsuario(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario(usuarioDTO.Email, usuarioDTO.Cpf, usuarioDTO.DataNascimento, usuarioDTO.Nome, usuarioDTO.Senha, usuarioDTO.UrlImagemCadastro, usuarioDTO.DataCriacao);
            await _repositorio(usuario);
            return usuario.id;
        }

        public async Task CadastrandoImagem(int id, IFormFile imagem)
        {
            var imagemValida = await _amazonService.ValidarImagem(nomeArquivo);
            var nomeArquivo = await _amazonService.SalvarNoS3(imagem);
            if (imagemValida)
            {
                await _repositorio.CadastrandoImagem(id, nomeArquivo);
                
            }
            else
            {
                await _amazonService.DeletarImagem("imagens-aula", nomeArquivo);
                throw new Exception("A imagem invalida.");
            }
        }               
        public async Task MudancaSenha(int id, string mudancaSenha)
        {
            await _repositorio.MudancaSenha(id, mudancaSenha);            
        }        
        public async Task<bool> LoginEmail(string email, string mudancaSenha)
        {
            var emailUsuario = await _repositorio.LoginEmail(email);
            var validarSenhaUsuario = await VerificarSenhaUsuario(emailUsuario, mudancaSenha);
            if (validarSenhaUsuario)
            {
                return true;
            }
            throw new Exception("Senha incorreta.");
        }
        public async Task<bool> VerificarSenhaUsuario(Usuario idUsuario, string senha)
        {
            if (idUsuario.Senha == senha)
            {
                return true;
            }
            return false;
        }        
        public async Task<bool> LoginPorImagem(Guid id, IFormFile image)
        {
            var buscarUsuarioId = await _repositorio.ListarUsuarioPorId(id);
            var buscarUsuarioImagem = await _amazonService.BuscaUsuarioImagem(buscarUsuarioId.UrlImagemCadastro, image);
            if(buscarUsuarioImagem)
            {
                return true;
            }
            throw new Exception ("Imagem não correspondente em cadastro.");
        }
        public async Task<bool> BuscaUsuarioImagem(string urlImagemCadastro, IFormFile image)
        {           
            var buscarUsuarioImagem = await _amazonService.BuscaUsuarioImagem(urlImagemCadastro, image);
            if(buscarUsuarioImagem)
            {
                return true;
            }
            throw new Exception ("Imagem não existe no banco de dados.");             
        }        
        public async Task DeletarUsuario(int id)
        {
            await _repositorio.DeletarUsuario(id);            
        }       
        
    }
}