using NasaAsteroid.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Utilities
{
    public class AsteroidFallStatusUtility : IAsteroidFallStatusUtility
    {
        public virtual FallStatus Convert(string fallStatus)
        {
            return fallStatus.ToLower() switch
            {
                "fall" => FallStatus.Fell,
                "found" => FallStatus.Found,
                _ => FallStatus.Unknown
            };
        }
    }
}
