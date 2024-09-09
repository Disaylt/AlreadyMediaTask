using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NasaAsteroid.Infrastructure.Database;
using NasaAsteroid.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Infrastructure
{
    internal static class InfrastructureLayerExtension
    {
        public static void AddInfrastructureLayer(this IServiceCollection collection, IConfiguration configuration)
        {
            IConfigurationSection connectionSection = configuration.GetSection("ConnectionStrings");

            string dbConnection = connectionSection.GetValue<string>("nasaAsteroids") ?? string.Empty;

            collection.AddDatabase(dbConnection);
            collection.AddRepositories();
        }
    }
}
