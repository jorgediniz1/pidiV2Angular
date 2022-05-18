using Labrasa.API.Domain.Models;

namespace Labrasa.API.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> Incluir(Produto produto);
        Task<Produto> Atualizar(Produto produto);
        Task<IEnumerable<Produto>> PegarTodos();
        Task<Produto> PegarPeloId(int id);
        Task<bool> Apagar (int id);
    }
}
