using IS.DZ03.Logic.Services;
using IS.DZ03.Logic.Services.Interfaces;
using IS.DZ03.Logic.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace IS.DZ03.Api.Extensions
{
    public static class ServiceDependencyInjectionExtension
    {
        public static IServiceCollection AddServicesToDependencyInjection(this IServiceCollection services)
        {
            _ = services.AddScoped<IAutomobilskeUslugeUnitOfWork, AutomobilskeUslugeUnitOfWork>();
            _ = services.AddScoped<IOsobaService, OsobaService>();

            return services; 
        }
    }
}
