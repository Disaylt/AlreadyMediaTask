using Microsoft.Extensions.DependencyInjection;
using NasaAsteroid.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Infrastructure.Cache
{
    public static class CacheRegistrationExtension
    {
        public static void AddChache(this IServiceCollection collection, string connectionString)
        {
            collection.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = connectionString;
            });
            collection.AddSingleton(typeof(ICacheRepository<>), typeof(CacheRepository<>));
        }
    }
}
