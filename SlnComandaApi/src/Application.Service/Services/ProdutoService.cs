using Domain.DTO;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;

namespace Application.Service.Services
{
    internal class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }


        public async Task<ProdutoDTO> FindById(int id)
        {
            var produto = new ProdutoDTO();
            return produto.mapToDTO(await _repository.FindById(id));
        }

        public async Task<ProdutoDTO> FindByLogin(string email)
        {
            var produto = new ProdutoDTO();
            return produto.mapToDTO(await _repository.FindByLogin(email));
        }

        public async Task<List<ProdutoDTO>> GetAll()
        {
            List<ProdutoDTO> listaDTO = new List<ProdutoDTO>();

            var lista = await _repository.GetAll();
            foreach (var item in lista)
            {
                var produto = new ProdutoDTO();
                listaDTO.Add(produto.mapToDTO(item));
            }

            return listaDTO;

        }

        public async Task<int> Save(ProdutoDTO entity)
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
