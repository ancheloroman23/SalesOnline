using Microsoft.Extensions.DependencyInjection;
using SalesOnline.Application.Contract;
using SalesOnline.Application.Service;
using SalesOnline.Infraestructure.Interfaces;
using SalesOnline.Infraestructure.Repositories;

namespace SalesOnline.Ioc.Dependencies
{
    public static class UsuarioDependency
    {
        public static void AddUsuarioDependecy(this IServiceCollection service)
        {
            service.AddScoped<IUsuarioRepository, UsuarioRepository>();
            service.AddTransient<IUsuarioService, UsuarioService>();
        }
    }
}
