using Aula.AWS.Lib.Interfaces;
using Aula.AWS.Lib.Models;
using Aula.AWS.Web.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Aula.AWS.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _repositorio;
        public static List<Usuario>ListaUsuarios {get; set;}=new List<Usuario>();

        public UsuarioController(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio; 
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
        [HttpPut]
        public async Task<IActionResult>Alterar(int  id, string senha)
        {
            await  _repositorio.AlteracaoSenhaAsync(id, senha);
            return Ok("Alteração de senha concluida.");
        }
    }
}