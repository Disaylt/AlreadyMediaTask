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

        public GetAsteroidsByYearGroupQueryHandler(ISpecificationExecutor<GetAsteroidsGroupYearSpecification, AsteroidYearGroupDto> specificationExecutor)
        {
            _specificationExecutor = specificationExecutor;
        }

        public async Task<IEnumerable<AsteroidYearGroupDto>> Handle(GetAsteroidsByYearGroupQuery request, CancellationToken cancellationToken)
        {
            return await _specificationExecutor.ExecuteAsync(request.Specification);
        }
    }
}
