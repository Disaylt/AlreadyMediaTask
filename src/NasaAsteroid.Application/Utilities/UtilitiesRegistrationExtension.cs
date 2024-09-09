using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Utilities
{
    internal static class UtilitiesRegistrationExtension
    {
        public static void AddUtilities(this IServiceCollection services)
        {
            services.AddSingleton<IAsteroidFallStatusUtility, AsteroidFallStatusUtility>();
            services.AddSingleton<IAsteroidMapper, AsteroidMapper>();
            services.AddSingleton<IAsteroidNameTypeUtility, AsteroidNameTypeUtility>();
        }
    }
}
