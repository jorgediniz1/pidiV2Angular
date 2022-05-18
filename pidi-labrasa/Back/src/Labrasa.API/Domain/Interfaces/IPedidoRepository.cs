using Labrasa.API.Domain.Models;

namespace Labrasa.API.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task<Pedido> Incluir(Pedido pedido);
        Task<Pedido> Atualizar(Pedido pedido);
        Task<IEnumerable<Pedido>> PegarTodos();
        Task<Pedido> PegarPeloId(int id);
        Task<bool> Apagar(int id);
    }
}
