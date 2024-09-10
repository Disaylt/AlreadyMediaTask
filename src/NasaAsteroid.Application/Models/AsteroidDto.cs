using NasaAsteroid.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Models
{
    public record class AsteroidDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = "Unknown";
        public string ClassType { get; init; } = "Unknown";
        public double? Mass { get; init; }
        public decimal? Longitude { get; init; }
        public decimal? Latitude { get; init; }
        public int Year { get; init; }
        public FallStatus Fall { get; init; }
        public NameType NameType { get; init; }
    }
}
