using Domain.Entity;
using Domain.Interfaces.IRepositories;

namespace Infra.Data.Repository.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly SQLServerContext _context;

        public UsuarioRepository(SQLServerContext context)
            : base(context)
        {
        }

        public async Task<Usuario> FindByLogin(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(p => p.Email == email);
        }
    }
}
