using Farmacia.Application.Interface.Interfaces;
using Farmacia.Persistence.Context;
using Farmacia.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Farmacia.Persistence.Extensions
{

    //Inyeccion de dependencia para el patron singleton de nuestro proyecto, usando una sola instancia de la base de datos
    public static class InjectionsExtensions
    {
        public static IServiceCollection AddInjectionPersistense(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationDBContext>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
