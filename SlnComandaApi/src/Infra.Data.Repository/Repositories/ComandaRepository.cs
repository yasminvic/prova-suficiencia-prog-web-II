using Domain.Entity;
using Domain.Interfaces.IRepositories;
using Infra.Data.Repository.Data;

namespace Infra.Data.Repository.Repositories
{
    public class ComandaRepository : BaseRepository<Comanda>, IComandaRepository
    {
        private readonly DataContext _context;

        public ComandaRepository(DataContext context)
            : base(context)
        {
        }
    }
}
