using Labrasa.API.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Labrasa.API.Domain.Identity
{
    public class FuncionarioRole : IdentityUserRole<int>
    {
        public Funcionario Funcionario { get; set; }
        public Role Role { get; set; }
    }
}
