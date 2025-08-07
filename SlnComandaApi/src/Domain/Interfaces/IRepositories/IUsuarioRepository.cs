using Domain.Entity;

namespace Domain.Interfaces.IRepositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> GetByEmail(string email);
    }
}
