using Domain.DTO;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;

namespace Application.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }

        public async Task<UsuarioDTO> FindById(int id)
        {
            var usuario = new UsuarioDTO();
            return usuario.mapToDTO(await _repository.FindById(id));
        }

        public async Task<UsuarioDTO> GetByEmail(string email)
        {
            UsuarioDTO user = new UsuarioDTO();
            return user.mapToDTO(await _repository.GetByEmail(email));
        }

        public async Task<List<UsuarioDTO>> GetAll()
        {
            List<UsuarioDTO> listaDTO = new List<UsuarioDTO>();

            var lista = await _repository.GetAll();
            foreach (var item in lista)
            {
                var usuario = new UsuarioDTO();
                listaDTO.Add(usuario.mapToDTO(item));
            }

            return listaDTO;

        }
        public async Task<int> Save(UsuarioDTO entity)
        {
            if (entity.id > 0)
            {
                return await _repository.Update(entity.mapToEntity());
            }
            else
            {
                return await _repository.Save(entity.mapToEntity());
            }
        }
    }
}
