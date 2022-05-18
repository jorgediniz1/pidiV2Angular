using Labrasa.API.Domain.Identity;
using Labrasa.API.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Labrasa.API.Infra.Context
{
    public class LabrasaContext : IdentityDbContext<Funcionario, Role, int,
                                                                        IdentityUserClaim<int>, FuncionarioRole, IdentityUserLogin<int>,
                                                                        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public LabrasaContext(DbContextOptions<LabrasaContext> opt) : base(opt) {}


        protected override void OnModelCreating(ModelBuilder builder)
        {          
                base.OnModelCreating(builder);
              
            
            builder.ApplyConfigurationsFromAssembly(typeof(LabrasaContext).Assembly);
        }


        public DbSet<Produto> Produtos { get; set; } 
        public DbSet<Comanda> Comandas { get; set; } 
        public DbSet<Funcionario> Funcionarios { get; set; } 
        public DbSet<Mesa> Mesas { get; set; } 
        public DbSet<Pedido> Pedidos { get; set; } 

    }
}
