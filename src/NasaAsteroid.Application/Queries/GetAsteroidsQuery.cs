using MediatR;
using NasaAsteroid.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Queries
{
    public class GetAsteroidsQuery : IRequest<IEnumerable<AsteroidDto>>
    {
        public int? FilterMinYear { get; set; }
        public int? FilterMaxYear { get; set; }
        public string? ClassType { get; set; }
        public string? NamePart { get; set; }
    }
}
