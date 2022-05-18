using Microsoft.AspNetCore.Identity;

namespace Labrasa.API.Domain.Identity
{
    public class Role : IdentityRole<int>
    {
        public List<FuncionarioRole> FuncionarioRoles { get; set; }
    }
}
