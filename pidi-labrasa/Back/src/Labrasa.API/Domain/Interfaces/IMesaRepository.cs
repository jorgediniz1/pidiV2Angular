using Labrasa.API.Domain.Models;

namespace Labrasa.API.Domain.Interfaces
{
    public interface IMesaRepository
    {
        Task<Mesa> Incluir(Mesa mesa);
        Task<Mesa> Atualizar(Mesa mesa);
        Task<IEnumerable<Mesa>> PegarTodas();
        Task<Mesa> PegarPeloId(int id);
        Task<bool> Apagar(int id);
    }
}
