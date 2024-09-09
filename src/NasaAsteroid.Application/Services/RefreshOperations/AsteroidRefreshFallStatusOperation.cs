using NasaAsteroid.Application.Models;
using NasaAsteroid.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Services.RefreshOperations
{
    public class AsteroidRefreshFallStatusOperation : IAsteroidRefreshValueOperation
    {
        public bool TryRefreshValue(Asteroid entity, AsteroidDto data)
        {
            bool isEquals = entity.FallStaus.Equals(data.Fall);

            if (isEquals == false)
            {
                entity.SetFallStatus(data.Fall);
            }

            return !isEquals;
        }
    }
}
