using Domain.Entity;
using Domain.Interfaces.IRepositories;
using Infra.Data.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly DataContext _context;

        public ProdutoRepository(DataContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<Produto>> GetAllByComanda(int comandaId)
        {
            return await _context.Produtos.Where(p => p.ComandaId == comandaId).ToListAsync();
        }
    }
}
