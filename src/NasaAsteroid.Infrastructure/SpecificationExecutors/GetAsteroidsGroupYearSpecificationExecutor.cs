using Microsoft.EntityFrameworkCore;
using NasaAsteroid.Application.Models;
using NasaAsteroid.Application.Specifications;
using NasaAsteroid.Domain.Entities;
using NasaAsteroid.Domain.Enums;
using NasaAsteroid.Domain.Seed;
using NasaAsteroid.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Infrastructure.SpecificationExecutors
{
    internal class GetAsteroidsGroupYearSpecificationExecutor : ISpecificationExecutor<GetAsteroidsGroupYearSpecification, AsteroidYearGroupDto>
    {
        private readonly AsteroidDbContext _context;

        public GetAsteroidsGroupYearSpecificationExecutor(AsteroidDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AsteroidYearGroupDto>> ExecuteAsync(GetAsteroidsGroupYearSpecification specification)
        {
            IQueryable<Asteroid> request = _context
                .Asteroids
                .AsQueryable();

            if (specification.FilterMinYear != null)
            {
                request = request.Where(a => a.Year.Value >= specification.FilterMinYear.Value);
            }

            if (specification.FilterMaxYear != null)
            {
                request = request.Where(a => a.Year.Value <= specification.FilterMaxYear.Value);
            }

            if (string.IsNullOrEmpty(specification.ClassType) == false)
            {
                request = request.Where(a => a.ClassType == specification.ClassType);
            }

            if (string.IsNullOrEmpty(specification.NamePart) == false)
            {
                request = request.Where(a => a.Name.Contains(specification.NamePart));
            }

            IQueryable<AsteroidYearGroupDto> groupQueryable = request.GroupBy(a => a.Year.Value)
                .Select(g => new AsteroidYearGroupDto
                {
                    Year = g.Key,
                    Quantity = g.Count(),
                    TotalMasss = g.Sum(a => a.Mass.Value.HasValue ? a.Mass.Value.Value : 0)
                });

            groupQueryable = specification.Sort switch
            {
                AsteroidSort.ByYear => groupQueryable.OrderBy(x => x.Year, specification.SortAsDesc),
                AsteroidSort.ByMass => groupQueryable.OrderBy(x => x.TotalMasss, specification.SortAsDesc),
                AsteroidSort.ByQuantity => groupQueryable.OrderBy(x => x.Quantity, specification.SortAsDesc),
                _ => groupQueryable
            };

            return await groupQueryable.ToListAsync();
        }
    }
}
