using Domain.DTO;
using Domain.Entity;

namespace Domain.Interfaces.IServices
{
    public interface IUsuarioService : IBaseService<UsuarioDTO>
    {
        Task<UsuarioDTO> GetByEmail(string email);
    }
}
