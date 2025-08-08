using Domain.Entity;

namespace Domain.Interfaces.IRepositories
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        Task<List<Produto>> GetAllByComanda(int comandaId);
    }
}
