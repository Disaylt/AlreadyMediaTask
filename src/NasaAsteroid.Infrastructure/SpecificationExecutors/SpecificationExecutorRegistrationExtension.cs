using Microsoft.Extensions.DependencyInjection;
using NasaAsteroid.Application.Models;
using NasaAsteroid.Application.Specifications;
using NasaAsteroid.Domain.Entities;
using NasaAsteroid.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Infrastructure.SpecificationExecutors
{
    internal static class SpecificationExecutorRegistrationExtension
    {
        public static void AddSpecificationExecutors(this IServiceCollection collection)
        {
            collection.AddScoped<ISpecificationExecutor<GetAsteroidsGroupYearSpecification, AsteroidYearGroupDto>, GetAsteroidsGroupYearSpecificationExecutor>();
            collection.AddScoped<ISpecificationExecutor<GetAsteroidsSpecification, Asteroid>, GetAsteroidsSpecificationExecutor>();
        }
    }
}
