using NasaAsteroid.Application.Models;
using NasaAsteroid.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Utilities
{
    public class AsteroidMapper : IAsteroidMapper
    {
        private readonly IAsteroidFallStatusUtility _asteroidFallStatusUtility;
        private readonly IAsteroidNameTypeUtility _asteroidNameTypeUtility;

        public AsteroidMapper(
            IAsteroidFallStatusUtility asteroidFallStatusUtility, 
            IAsteroidNameTypeUtility asteroidNameTypeUtility)
        {
            _asteroidFallStatusUtility = asteroidFallStatusUtility;
            _asteroidNameTypeUtility = asteroidNameTypeUtility;
        }

        public AsteroidDto FromEntity(Asteroid entity)
        {
            return new AsteroidDto
            {
                ClassType = entity.ClassType,
                Year = entity.Year.Value,
                Fall = entity.FallStaus,
                Id = entity.Id,
                Latitude = entity.Coordinates.Latitude,
                Longitude = entity.Coordinates.Longitude,
                Mass = entity.Mass.Value,
                Name = entity.Name,
                NameType = entity.NameType
            };
        }

        public virtual AsteroidDto FromWeb(AsteroidWebModel asteroid)
        {
            if(int.TryParse(asteroid.Id, out var id) == false)
            {
                throw new ArgumentException($"Impossible convert id:{asteroid.Id} to int");
            }

            bool isValidMass = double.TryParse(asteroid.Mass, NumberStyles.Any, CultureInfo.InvariantCulture, out double mass);
            bool isValidLongitude = decimal.TryParse(asteroid.Reclong, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal longitude);
            bool isValidLatitude = decimal.TryParse(asteroid.Reclat, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal latitude);

            return new AsteroidDto
            {
                Id = id,
                Mass = isValidMass ? mass : null,
                Longitude = isValidLongitude ? longitude : null,
                Latitude = isValidLatitude ? latitude : null,
                ClassType = asteroid.Recclass,
                Fall = _asteroidFallStatusUtility.Convert(asteroid.Fall),
                Name = asteroid.Name,
                NameType = _asteroidNameTypeUtility.Convert(asteroid.Name),
                Year = asteroid.Date.Year
            };
        }
    }
}
