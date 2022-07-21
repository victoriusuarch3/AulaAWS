using Aula.AWS.Lib.Models;

namespace Aula.AWS.Lib.Interfaces
{
    public interface IBaseRepositorio <T> where T : ModelBase
    {
        Task <List<T>> PesquisaAsync();
        Task <T> PesquisaAsyncId(int id);
        Task AddAsync(T item);
        Task  DeletarAsync(int id);
    }
}