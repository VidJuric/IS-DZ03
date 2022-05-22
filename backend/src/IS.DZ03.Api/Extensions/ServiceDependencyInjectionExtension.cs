using IS.DZ03.Logic.Services;
using IS.DZ03.Logic.Services.Interfaces;
using IS.DZ03.Logic.Services.Sieves;
using IS.DZ03.Logic.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Services;

namespace IS.DZ03.Api.Extensions
{
    public static class ServiceDependencyInjectionExtension
    {
        public static IServiceCollection AddServicesToDependencyInjection(this IServiceCollection services)
        {
            _ = services.AddScoped<IAutomobilskeUslugeUnitOfWork, AutomobilskeUslugeUnitOfWork>();
            _ = services.AddScoped<IOsobaService, OsobaService>();
            _ = services.AddScoped<IStatusZadatkaService, StatusZadatakaService>();
            _ = services.AddScoped<IUslugaService, UslugaService>();
            _ = services.AddScoped<IZadatakService, ZadatakService>();
            _ = services.AddScoped<ISieveProcessor, AutomobilskeUslugeSieveProcessor>();

            return services; 
        }
    }
}
