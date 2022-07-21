using Aula.AWS.Lib.Models;

namespace Aula.AWS.Lib.Interfaces
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
       Task AlteracaoSenhaAsync(int id, string senha);
       Task AddAsync();
    }
}
