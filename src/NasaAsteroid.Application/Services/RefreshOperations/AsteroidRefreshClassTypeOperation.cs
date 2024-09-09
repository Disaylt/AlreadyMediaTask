using NasaAsteroid.Application.Models;
using NasaAsteroid.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Services.RefreshOperations
{
    public class AsteroidRefreshClassTypeOperation : IAsteroidRefreshValueOperation
    {
        public bool TryRefreshValue(Asteroid entity, AsteroidDto data)
        {
            bool isEquals = entity.ClassType.Equals(data.ClassType);

            if(isEquals == false)
            {
                entity.SetClassType(data.ClassType);
            }

            return !isEquals;
        }
    }
}
