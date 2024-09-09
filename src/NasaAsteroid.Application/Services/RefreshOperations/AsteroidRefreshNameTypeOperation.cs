﻿using NasaAsteroid.Application.Models;
using NasaAsteroid.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Services.RefreshOperations
{
    public class AsteroidRefreshNameTypeOperation : IAsteroidRefreshValueOperation
    {
        public bool TryRefreshValue(Asteroid entity, AsteroidDto data)
        {
            bool isEquals = entity.NameType.Equals(data.NameType);

            if (isEquals == false)
            {
                entity.SetNameType(data.NameType);
            }

            return !isEquals;
        }
    }
}
