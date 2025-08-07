namespace Domain.DTO
{
    public class ComandaDTO
    {
        public int id { get; set; }
        public int idUsuario { get; set; }
        public string nomeUsuario { get; set; }
        public string telefoneUsuario { get; set; }
        public List<ProdutoDTO> produtos { get; set; }
    }
}
