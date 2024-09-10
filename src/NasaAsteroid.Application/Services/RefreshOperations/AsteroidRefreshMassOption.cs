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
    public class AsteroidRefreshMassOption : IAsteroidRefreshValueOperation
    {
        public bool TryRefreshValue(Asteroid entity, AsteroidDto data)
        {
            Mass newMass = new Mass(data.Mass);
            bool isEquals = entity.Mass.Equals(newMass);

            if (isEquals == false)
            {
                entity.SetMass(newMass);
            }

            return !isEquals;
        }
    }
}
