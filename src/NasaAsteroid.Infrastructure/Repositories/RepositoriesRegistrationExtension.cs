using Microsoft.Extensions.DependencyInjection;
using NasaAsteroid.Domain.Repositories;
using NasaAsteroid.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Infrastructure.Repositories
{
    internal static class RepositoriesRegistrationExtension
    {
        public static void AddRepositories(this IServiceCollection collection)
        {
            collection.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            collection.AddScoped<IAsteroidRepository, AsteroidRepository>();
        }
    }
}
