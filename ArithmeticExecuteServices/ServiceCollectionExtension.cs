using ArithmeticExecuteServices.Services.Implementations;
using ArithmeticExecuteServices.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ArithmeticExecuteServices.Services
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection serviceCollection)
        {
            //DI container - 
            // Used to add a service registration to the Apprenticeship container
            //so that the service will be built once for the entire lifetime (scope) determined by AddScoped.
            //Usually, using AddScoped is suitable for situations where you want to share between several dependencies (dependencies) in the same scope

            serviceCollection.AddScoped<IArithmeticExecuteService, ArithmeticExecuteService>();
            serviceCollection.AddScoped<IAuthorizeService, AuthorizeService>();
        }
    }
}