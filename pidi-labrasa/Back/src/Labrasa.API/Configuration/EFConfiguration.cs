using Labrasa.API.Domain.Models;
using Labrasa.API.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Labrasa.API.Configuration
{
    public static class EFConfiguration
    {
        public static void AddEFConfigurations(this IServiceCollection services, IConfiguration config)
        {

            services.AddDefaultIdentity<Funcionario>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<LabrasaContext>();

            // Add services DbContext
            services.AddDbContext<LabrasaContext>(x => x.UseSqlServer(
                config.GetConnectionString("DefaultConnection")
                ));
        }
    }
}
