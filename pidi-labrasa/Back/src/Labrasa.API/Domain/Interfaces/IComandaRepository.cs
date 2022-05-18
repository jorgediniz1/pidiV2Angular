using Labrasa.API.Domain.Models;

namespace Labrasa.API.Domain.Interfaces
{
    public interface IComandaRepository
    {
        Task<Comanda> Incluir(Comanda comanda);
        Task<Comanda> Atualizar(Comanda comanda);
        Task<IEnumerable<Comanda>> PegarTodos();
        Task<Comanda> PegarPeloId(int id);
        Task<bool> Apagar(int id);
    }
}
