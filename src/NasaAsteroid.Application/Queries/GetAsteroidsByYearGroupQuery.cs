using MediatR;
using NasaAsteroid.Application.Models;
using NasaAsteroid.Application.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Queries
{
    public class GetAsteroidsByYearGroupQuery : IRequest<IEnumerable<AsteroidYearGroupDto>>
    {
        public required GetAsteroidsGroupYearSpecification Specification { get; set; }
    }
}
