using Labrasa.API.Domain.Interfaces;
using Labrasa.API.Infra.Repository;

namespace Labrasa.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IMesaRepository, MesaRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IComandaRepository, ComandaRepository>();
        }
    }
}
