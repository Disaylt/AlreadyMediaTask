using MediatR;
using NasaAsteroid.Application.Models;
using NasaAsteroid.Application.Specifications;
using NasaAsteroid.Application.Utilities;
using NasaAsteroid.Domain.Entities;
using NasaAsteroid.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Queries
{
    public class GetAsteroidsQueryHandler : IRequestHandler<GetAsteroidsQuery, IEnumerable<AsteroidDto>>
    {
        private readonly ISpecificationExecutor<GetAsteroidsSpecification, Asteroid> _specificationExecutor;
        private readonly ICacheRepository<AsteroidDto> _cacheRepository;
        private readonly IAsteroidMapper _asteroidMapper;

        public GetAsteroidsQueryHandler(IAsteroidMapper asteroidMapper,
            ICacheRepository<AsteroidDto> cacheRepository,
        ISpecificationExecutor<GetAsteroidsSpecification, Asteroid> specificationExecutor)
        {
            _specificationExecutor = specificationExecutor;
            _asteroidMapper = asteroidMapper;
            _cacheRepository = cacheRepository;
        }

        public async Task<IEnumerable<AsteroidDto>> Handle(GetAsteroidsQuery request, CancellationToken cancellationToken)
        {
            string key = request.Specification.GetMetaData();

            IEnumerable<AsteroidDto>? cacheAsteroids = await _cacheRepository.GetRangeAsync(key);

            if (cacheAsteroids == null)
            {
                IEnumerable<Asteroid> enties = await _specificationExecutor.ExecuteAsync(request.Specification);
                IEnumerable<AsteroidDto> asteroids = enties.Select(_asteroidMapper.FromEntity);
                await _cacheRepository.SetRangeAsync(key, asteroids, TimeSpan.FromMinutes(5));

                return asteroids;
            }

            return cacheAsteroids;
        }
    }
}
