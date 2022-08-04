using Aula.AWS.Lib.Models;

namespace Aula.AWS.Lib.Interfaces
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
       Task AlteracaoSenha(int id, string senha);
    }
}
