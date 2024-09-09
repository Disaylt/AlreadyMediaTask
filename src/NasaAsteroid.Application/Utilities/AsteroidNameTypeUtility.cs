using NasaAsteroid.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Utilities
{
    public class AsteroidNameTypeUtility : IAsteroidNameTypeUtility
    {
        public NameType Convert(string value)
        {
            return value.ToLower() switch
            {
                "valid" => NameType.Valid,
                _ => NameType.Unknown
            };
        }
    }
}
