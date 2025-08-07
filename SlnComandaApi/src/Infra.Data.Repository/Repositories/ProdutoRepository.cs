using Domain.Entity;
using Domain.Interfaces.IRepositories;
using Infra.Data.Repository.Data;

namespace Infra.Data.Repository.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly DataContext _context;

        public ProdutoRepository(DataContext context)
            : base(context)
        {
        }
    }
}
