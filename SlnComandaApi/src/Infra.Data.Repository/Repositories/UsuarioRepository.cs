using Domain.Entity;
using Domain.Interfaces.IRepositories;
using Infra.Data.Repository.Data;

namespace Infra.Data.Repository.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
            : base(context)
        {
        }

        public async Task<Usuario> GetByEmail(string email)
        {
            return _context.Usuarios.Where(user => user.Email == email).FirstOrDefault();
        }
    }
}
