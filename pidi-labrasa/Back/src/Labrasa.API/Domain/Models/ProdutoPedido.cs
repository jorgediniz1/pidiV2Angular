namespace Labrasa.API.Domain.Models
{
    public class ProdutoPedido
    {
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        
    }
}
