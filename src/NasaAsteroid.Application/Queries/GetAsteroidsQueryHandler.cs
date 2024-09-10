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
        private readonly IAsteroidMapper _asteroidMapper;

        public GetAsteroidsQueryHandler(IAsteroidMapper asteroidMapper,
            ISpecificationExecutor<GetAsteroidsSpecification, Asteroid> specificationExecutor)
        {
            _specificationExecutor = specificationExecutor;
            _asteroidMapper = asteroidMapper;
        }

        public async Task<IEnumerable<AsteroidDto>> Handle(GetAsteroidsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Asteroid> enties = await _specificationExecutor.ExecuteAsync(request.Specification);

            return enties.Select(_asteroidMapper.FromEntity);
        }
    }
}
