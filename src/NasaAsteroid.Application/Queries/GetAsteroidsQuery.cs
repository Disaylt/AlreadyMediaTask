using MediatR;
using NasaAsteroid.Application.Models;
using NasaAsteroid.Application.Specifications;
using NasaAsteroid.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Queries
{
    public class GetAsteroidsQuery : IRequest<IEnumerable<AsteroidDto>>
    {
        public required GetAsteroidsSpecification Specification { get; set; }
    }
}
