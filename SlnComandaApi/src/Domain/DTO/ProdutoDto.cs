using Domain.Entity;

namespace Domain.DTO
{
    public class ProdutoDTO
    {
        public int id { get; set; }
        public string nome { get; set; }
        public decimal preco { get; set; }
        public int comandaId { get; set; }

        public ProdutoDTO mapToDTO(Produto produto)
        {
            if (produto == null)
            {
                return null;
            }
            return new ProdutoDTO
            {
                id = produto.Id,
                nome = produto.Nome,
                preco = produto.Preco,
                comandaId = produto.ComandaId
            };
        }

        public Produto mapToEntity()
        {
            return new Produto
            {
                Id = id,
                Nome = nome,
                Preco = preco,
                ComandaId = comandaId
            };
        }
    }
}
