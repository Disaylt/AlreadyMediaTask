using NasaAsteroid.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Models
{
    public class AsteroidsQueriesDto
    {
        public int? FilterMinYear { get; set; }
        public int? FilterMaxYear { get; set; }
        public string? ClassType { get; set; }
        public string? NamePart { get; set; }
        public AsteroidSort Sort { get; set; } = AsteroidSort.Default;
    }
}
