using Aula.AWS.Application.DTOs;
using Aula.AWS.Lib.Models;
using Microsoft.AspNetCore.Http;

namespace Aula.AWS.Application.Services
{
    public class IUsuarioApplication
    {
        Task<List<Usuario>> ListarUsuario();   
        Task DeletarUsuario(int id); 
        Task CadastrandoImagem(int id, IFormFile imagem);
        Task <Guid>AddUsuario(UsuarioDTO usuarioDTO);        
        Task MudancaSenha(int id, string mudancaSenha);
        Task<bool> VerificarSenhaUsuario(Usuario idUsuario, string senha);
        Task<bool> BuscaUsuarioImagem(string urlImagemCadastro, IFormFile image);
        Task<bool> LoginEmail(string email, string senha); 
    }
}

