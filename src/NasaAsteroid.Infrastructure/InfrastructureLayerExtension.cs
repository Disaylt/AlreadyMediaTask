﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NasaAsteroid.Infrastructure.Cache;
using NasaAsteroid.Infrastructure.Database;
using NasaAsteroid.Infrastructure.HttpClients;
using NasaAsteroid.Infrastructure.Repositories;
using NasaAsteroid.Infrastructure.SpecificationExecutors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Infrastructure
{
    public static class InfrastructureLayerExtension
    {
        public static void AddInfrastructureLayer(this IServiceCollection collection, IConfiguration configuration)
        {
            IConfigurationSection connectionSection = configuration.GetSection("ConnectionStrings");

            string dbConnection = connectionSection.GetValue<string>("nasaAsteroids") ?? string.Empty;
            string redisConnection = connectionSection.GetValue<string>("redis") ?? string.Empty;

            collection.AddDatabase(dbConnection);
            collection.AddRepositories();
            collection.AddOwnHttpClients();
            collection.AddSpecificationExecutors();
            collection.AddChache(redisConnection);
        }
    }
}
