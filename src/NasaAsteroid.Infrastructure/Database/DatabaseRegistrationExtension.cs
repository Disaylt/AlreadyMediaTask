using Microsoft.Extensions.DependencyInjection;
using NasaAsteroid.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Infrastructure.Database
{
    internal static class DatabaseRegistrationExtension
    {
        public static void AddDatabase(this IServiceCollection collection, string connectionString)
        {
            collection.AddNpgsql<AsteroidDbContext>(connectionString);
            collection.AddScoped<IUnitOfWork, AsteroidDbContext>();
        }
    }
}
