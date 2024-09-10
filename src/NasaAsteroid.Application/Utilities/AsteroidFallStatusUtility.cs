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
            string lowerFallStatus = fallStatus.ToLower();
            return lowerFallStatus switch
            {
                "fell" => FallStatus.Fell,
                "found" => FallStatus.Found,
                _ => FallStatus.Unknown
            };
        }
    }
}
