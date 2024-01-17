using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Farmacia.Application.UseCase.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services)
        {
           services.AddMediatR(X => X.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
           services.AddAutoMapper(Assembly.GetExecutingAssembly());
           services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
