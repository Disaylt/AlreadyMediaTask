using NasaAsteroid.Application.Models;
using NasaAsteroid.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Utilities
{
    public interface IAsteroidMapper
    {
        AsteroidDto FromWeb(AsteroidWebModel asteroid);
        AsteroidDto FromEntity(Asteroid entity);
    }
}
