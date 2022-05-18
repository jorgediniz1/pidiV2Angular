using Labrasa.API.Domain.Models;

namespace Labrasa.API.Domain.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task<Funcionario> Incluir(Funcionario funcionario);
        Task<Funcionario> Atualizar(Funcionario funcionario);
        Task<IEnumerable<Funcionario>> PegarTodos();
        Task<Funcionario> PegarPeloId(int id);
        Task<bool> Apagar(int id);

    }
}
