using Domain.DTO;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;

namespace Application.Service.Services
{
    public class ComandaService : IComandaService
    {
        private readonly IComandaRepository _repository;

        public ComandaService(IComandaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }

        public async Task<ComandaDTO> FindById(int id)
        {
            var comanda = new ComandaDTO();
            return comanda.mapToDTO(await _repository.FindById(id));
        }

        public async Task<ComandaDTO> FindByLogin(string email)
        {
            var comanda = new ComandaDTO();
            return comanda.mapToDTO(await _repository.FindByLogin(email));
        }

        public async Task<List<ComandaDTO>> GetAll()
        {
            List<ComandaDTO> listaDTO = new List<ComandaDTO>();

            var lista = await _repository.GetAll();
            foreach (var item in lista)
            {
                var comanda = new ComandaDTO();
                listaDTO.Add(comanda.mapToDTO(item));
            }

            return listaDTO;

        }

        public async Task<int> Save(ComandaDTO entity)
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
