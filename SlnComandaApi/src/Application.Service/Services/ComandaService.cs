using Domain.DTO;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;

namespace Application.Service.Services
{
    public class ComandaService : IComandaService
    {
        private readonly IComandaRepository _repository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IProdutoRepository _produtoRepository;

        public ComandaService(IComandaRepository repository, IUsuarioRepository usuarioRepository, IProdutoRepository produtoRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            if (entity == null)
            {
                return -1;
            }
            return await _repository.Delete(entity);
        }

        public async Task<ComandaDTO> FindById(int id)
        {
            var comanda = new ComandaDTO();
            comanda = comanda.mapToDTO(await _repository.FindById(id));

            var usuarioDTO = new UsuarioDTO();
            var aux = usuarioDTO.mapToDTO(await _usuarioRepository.FindById(comanda.usuarioId));
            comanda.nomeUsuario = aux.nome;
            comanda.telefoneUsuario = aux.telefone;
 
            var listaProduto = await _produtoRepository.GetAllByComanda(comanda.id);
            foreach (var produto in listaProduto)
            {
                var dto = new ProdutoDTO();
                comanda.produtos.Add(dto.mapToDTO(produto));
            }

            return comanda;
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

            foreach (var comanda in listaDTO)
            {
                var usuarioDTO = new UsuarioDTO();
                var aux = usuarioDTO.mapToDTO(await _usuarioRepository.FindById(comanda.usuarioId));
                comanda.nomeUsuario = aux.nome;
                comanda.telefoneUsuario = aux.telefone;

                var listaProduto = await _produtoRepository.GetAllByComanda(comanda.id);
                foreach (var produto in listaProduto)
                {
                    var dto = new ProdutoDTO();
                    comanda.produtos.Add(dto.mapToDTO(produto));
                }
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
