using Domain.Entity;
using Domain.Interfaces.IRepositories;

namespace Infra.Data.Repository.Repositories
{
    public class ComandaRepository : BaseRepository<Comanda>, IComandaRepository
    {
        private readonly SQLServerContext _context;

        public ComandaRepository(SQLServerContext context)
            : base(context)
        {
        }
    }
}
