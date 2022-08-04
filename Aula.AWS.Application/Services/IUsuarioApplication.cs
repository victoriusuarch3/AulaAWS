using Aula.AWS.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace Aula.AWS.Application.Services
{
    public class IUsuarioApplication
    {
        Task CadastrarUsuario(UsuarioDTO dto);
        Task CadastrarImagemUsuario(int usuarioId, IFormFile imagem);
    }
}