using MediatR;
using NasaAsteroid.Application.Models;
using NasaAsteroid.Application.Specifications;
using NasaAsteroid.Domain.Entities;
using NasaAsteroid.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Queries
{
    public class GetAsteroidsByYearGroupQueryHandler : IRequestHandler<GetAsteroidsByYearGroupQuery, IEnumerable<AsteroidYearGroupDto>>
    {
        private readonly ISpecificationExecutor<GetAsteroidsGroupYearSpecification, AsteroidYearGroupDto> _specificationExecutor;
        private readonly ICacheRepository<AsteroidYearGroupDto> _cacheRepository;

        public GetAsteroidsByYearGroupQueryHandler(ICacheRepository<AsteroidYearGroupDto> cacheRepository,
            ISpecificationExecutor<GetAsteroidsGroupYearSpecification, AsteroidYearGroupDto> specificationExecutor)
        {
            _specificationExecutor = specificationExecutor;
            _cacheRepository = cacheRepository;
        }

        public async Task<IEnumerable<AsteroidYearGroupDto>> Handle(GetAsteroidsByYearGroupQuery request, CancellationToken cancellationToken)
        {
            string key = request.Specification.GetMetaData();

            IEnumerable<AsteroidYearGroupDto>? cahceAsteroids = await _cacheRepository.GetRangeAsync(request.Specification.GetMetaData());

            if (cahceAsteroids == null)
            {
                IEnumerable<AsteroidYearGroupDto> asteroids = await _specificationExecutor.ExecuteAsync(request.Specification);
                await _cacheRepository.SetRangeAsync(key, asteroids, TimeSpan.FromMinutes(5));

                return asteroids;
            }

            return cahceAsteroids;
        }
    }
}
