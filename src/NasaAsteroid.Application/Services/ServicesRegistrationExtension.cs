using Microsoft.Extensions.DependencyInjection;
using NasaAsteroid.Application.Services.RefreshOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Services
{
    internal static class ServicesRegistrationExtension
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IAsteroidService, AsteroidService>();
            services.AddSingleton<IAsteroidRefreshFacade, AsteroidRefreshFacade>();

            services.AddSingleton<IAsteroidRefreshValueOperation, AsteroidRefreshClassTypeOperation>();
            services.AddSingleton<IAsteroidRefreshValueOperation, AsteroidRefreshCoordinatesOperation>();
            services.AddSingleton<IAsteroidRefreshValueOperation, AsteroidRefreshFallStatusOperation>();
            services.AddSingleton<IAsteroidRefreshValueOperation, AsteroidRefreshMassOption>();
            services.AddSingleton<IAsteroidRefreshValueOperation, AsteroidRefreshNameOperation>();
            services.AddSingleton<IAsteroidRefreshValueOperation, AsteroidRefreshNameTypeOperation>();
        }
    }
}
