using NasaAsteroid.Application.Models;
using NasaAsteroid.Domain.Entities;
using NasaAsteroid.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Services
{
    internal class AsteroidService : IAsteroidService
    {
        public Asteroid Build(AsteroidDto data)
        {
            return new Asteroid(data.Id,
                data.Name,
                new Mass(data.Mass),
                data.Year,
                new Coordinates(data.Longitude, data.Latitude),
                data.Fall,
                data.NameType,
                data.ClassType);
        }
    }
}
