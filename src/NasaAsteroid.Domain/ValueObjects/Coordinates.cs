using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Domain.ValueObjects
{
    public class Coordinates : BaseValueObject
    {
        public decimal? Longitude { get; private set; }
        public decimal? Latitude { get; private set; }

        public Coordinates(decimal? longitude, decimal? latitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Longitude;
            yield return Latitude;
        }
    }
}
