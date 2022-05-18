namespace Labrasa.API.Domain.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int QuantidadeMinima { get; set; }
        public double PrecoCusto { get; set; }
        public double PrecoVenda { get; set; }
        public List<Pedido> Pedidos { get; set; }
    }
}
