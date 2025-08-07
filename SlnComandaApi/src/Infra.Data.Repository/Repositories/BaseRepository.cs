using Domain.Interfaces.IRepositories;
using Infra.Data.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(T entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<T> FindById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<int> Save(T entity)
        {
            _context.Set<T>().Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
