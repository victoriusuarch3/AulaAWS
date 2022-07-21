using Aula.AWS.Lib.Data;
using Aula.AWS.Lib.Interfaces;
using Aula.AWS.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula.AWS.Lib.Repositorio
{
    public class BaseRepositorio<T> : IBaseRepositorio<T> where T : ModelBase
    {
        private readonly AulaAWSContext _context;
        private readonly DbSet<T> _dbset;
        public BaseRepositorio(AulaAWSContext dbContext, DbSet<T> dbset)
        {
            _context = dbContext;
            _dbset = _dbset;
        }
        public async Task<List<T>> PesquisaAsync()
        {
            return await _dbset.AsNoTracking().ToListAsync();
        }
        public async Task<T> PesquisaAsyncId(int id)
        {
            return await _dbset.AsNoTracking().FirstAsync(x => x.id == id);
        }
        public async Task AddAsync(T item)
        {
            await _dbset.AddAsync(item);
            await _context.SaveChangesAsync();
        }
        public async Task DeletarAsync(int id)
        {
            var item = await _dbset.AsNoTracking().FirstAsync(x => x.id == id);
            _dbset.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}