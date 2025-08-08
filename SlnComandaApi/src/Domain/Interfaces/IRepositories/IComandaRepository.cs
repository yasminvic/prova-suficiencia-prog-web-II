using Domain.Entity;

namespace Domain.Interfaces.IRepositories
{
    public interface IComandaRepository : IBaseRepository<Comanda>
    {
        Task<List<Comanda>> GetAll();
    }
}
