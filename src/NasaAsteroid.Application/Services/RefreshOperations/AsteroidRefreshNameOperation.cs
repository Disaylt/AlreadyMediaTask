using NasaAsteroid.Application.Models;
using NasaAsteroid.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Services.RefreshOperations
{
    public class AsteroidRefreshNameOperation : IAsteroidRefreshValueOperation
    {
        public bool TryRefreshValue(Asteroid entity, AsteroidDto data)
        {
            bool isEquals = entity.Name.Equals(data.Name);

            if (isEquals == false)
            {
                entity.SetName(data.Name);
            }

            return !isEquals;
        }
    }
}
