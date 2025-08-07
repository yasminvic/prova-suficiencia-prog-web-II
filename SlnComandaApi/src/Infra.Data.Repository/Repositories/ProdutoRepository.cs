using Domain.Entity;
using Domain.Interfaces.IRepositories;

namespace Infra.Data.Repository.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly SQLServerContext _context;

        public ProdutoRepository(SQLServerContext context)
            : base(context)
        {
        }
    }
}
