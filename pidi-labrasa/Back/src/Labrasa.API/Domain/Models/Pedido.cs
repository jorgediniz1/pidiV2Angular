namespace Labrasa.API.Domain.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataHoraPedido { get; set; }
        public double ValorPedido { get; set; }
        public int ComandaId { get; set; }
        public Comanda Comanda { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
