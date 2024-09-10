using NasaAsteroid.Application.Models;
using NasaAsteroid.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Services.RefreshOperations
{
    public interface IAsteroidRefreshValueOperation
    {
        bool TryRefreshValue(Asteroid entity, AsteroidDto data);
    }
}
