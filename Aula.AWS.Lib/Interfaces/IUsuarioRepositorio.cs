using Aula.AWS.Lib.Models;

namespace Aula.AWS.Lib.Interfaces
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        public Task MudancaSenha(int id, string MudancaSenha);
        public Task AlterarEmail(int id, string alterarEmail);
        public Task AlterarNome(int id, string alterarNome);
        public Task CadastrandoImagem (int id, string CadastrandoImagem);
        public Task<Usuario> LoginEmail(string emailDoUsuario);
    }
}
