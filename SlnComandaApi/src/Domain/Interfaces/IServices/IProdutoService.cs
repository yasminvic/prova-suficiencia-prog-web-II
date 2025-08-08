using Domain.DTO;
using Domain.Entity;

namespace Domain.Interfaces.IServices
{
    public interface IProdutoService : IBaseService<ProdutoDTO>
    {
        Task<List<ProdutoDTO>> GetAllByComanda(int comandaId);
    }
}
