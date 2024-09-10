using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Models
{
    public record class AsteroidYearGroupDto
    {
        public int Year { get; init; }
        public int Quantity { get; init; }
        public double TotalMasss { get; init; }

    }
}
