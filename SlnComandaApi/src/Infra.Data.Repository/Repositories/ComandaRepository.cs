using Domain.Entity;
using Domain.Interfaces.IRepositories;
using Infra.Data.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository.Repositories
{
    public class ComandaRepository : BaseRepository<Comanda>, IComandaRepository
    {
        private readonly DataContext _context;

        public ComandaRepository(DataContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<Comanda>> GetAll()
        {
            return await _context.Comandas
                .Include(c => c.Usuario)
                .ToListAsync();
        }
    }
}
