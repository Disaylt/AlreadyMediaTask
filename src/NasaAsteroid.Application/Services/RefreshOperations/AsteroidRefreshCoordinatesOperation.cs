using NasaAsteroid.Application.Models;
using NasaAsteroid.Domain.Entities;
using NasaAsteroid.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Services.RefreshOperations
{
    public class AsteroidRefreshCoordinatesOperation : IAsteroidRefreshValueOperation
    {
        public bool TryRefreshValue(Asteroid entity, AsteroidDto data)
        {
            Coordinates newCoordinates = new Coordinates(data.Longitude, data.Latitude);

            bool isEquals = entity
                .Coordinates
                .Equals(newCoordinates);

            if (isEquals == false)
            {
                entity.SetCoordinates(newCoordinates);
            }

            return !isEquals;
        }
    }
}
