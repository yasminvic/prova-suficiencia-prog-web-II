using Domain.Entity;

namespace Domain.DTO
{
    public class ComandaDTO
    {
        public int id { get; set; }
        public int usuarioId { get; set; }
        public string nomeUsuario { get; set; }
        public string telefoneUsuario { get; set; }
        public List<ProdutoDTO>? produtos { get; set; }

        public ComandaDTO mapToDTO(Comanda comanda)
        {
            if (comanda == null)
            {
                return null;
            }

            return new ComandaDTO
            {
                id = comanda.Id,
                usuarioId = comanda.UsuarioId,
                nomeUsuario = comanda.Usuario?.Nome ?? string.Empty,
                telefoneUsuario = comanda.Usuario?.Telefone ?? string.Empty,
                produtos = comanda.Produtos?.Select(p => new ProdutoDTO
                {
                    id = p.Id,
                    nome = p.Nome,
                    preco = p.Preco
                }).ToList() ?? new List<ProdutoDTO>()
            };
        }

        public Comanda mapToEntity()
        {
            return new Comanda
            {
                Id = id,
                UsuarioId = usuarioId,
                Usuario = new Usuario
                {
                    Nome = nomeUsuario,
                    Telefone = telefoneUsuario
                },
                Produtos = produtos?.Select(p => new Produto
                {
                    Id = p.id,
                    Nome = p.nome,
                    Preco = p.preco
                }).ToList() ?? new List<Produto>()
            };
        }
    }
}
