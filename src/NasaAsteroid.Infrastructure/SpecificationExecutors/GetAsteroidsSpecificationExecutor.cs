using Microsoft.EntityFrameworkCore;
using NasaAsteroid.Application.Specifications;
using NasaAsteroid.Domain.Entities;
using NasaAsteroid.Domain.Enums;
using NasaAsteroid.Domain.Seed;
using NasaAsteroid.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Infrastructure.SpecificationExecutors
{
    internal class GetAsteroidsSpecificationExecutor : ISpecificationExecutor<GetAsteroidsSpecification, Asteroid>
    {
        private readonly AsteroidDbContext _context;

        public GetAsteroidsSpecificationExecutor(AsteroidDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asteroid>> ExecuteAsync(GetAsteroidsSpecification specification)
        {
            IQueryable<Asteroid> request = _context
                .Asteroids
                .AsQueryable();

            if(specification.FilterMinYear != null)
            {
                request = request.Where(a => a.Year.Value >= specification.FilterMinYear.Value);
            }

            if(specification.FilterMaxYear != null)
            {
                request = request.Where(a=> a.Year.Value <= specification.FilterMaxYear.Value);
            }

            if(string.IsNullOrEmpty(specification.ClassType) == false)
            {
                request = request.Where(a => a.ClassType == specification.ClassType);
            }

            if(string.IsNullOrEmpty(specification.NamePart) == false)
            {
                request = request.Where(a => a.Name.Contains(specification.NamePart));
            }

            request = specification.Sort switch
            {
                AsteroidSort.ByMass => request.OrderBy(x => x.Mass, specification.SortAsDesc),
                AsteroidSort.ByYear => request.OrderBy(x => x.Year.Value, specification.SortAsDesc),
                _ => request
            };

            return await request.ToListAsync();
        }
    }
}
