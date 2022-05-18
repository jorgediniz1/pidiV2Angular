using Labrasa.API.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace Labrasa.API.Domain.Models
{
    public class Funcionario : IdentityUser<int>
    {
        public string Departamento { get; set; }
        public string Cpf { get; set; }
        public string Sexo { get; set; }
        public string Endereco { get; set; }
        public IEnumerable<FuncionarioRole> FuncionarioRoles { get; set; }

        public List<Comanda> Comandas { get; set; }

    }
}
