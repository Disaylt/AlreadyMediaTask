using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Domain.Enums
{
    public enum AsteroidGroup
    {
        None = 0,
        Year
    }

    public enum AsteroidSort
    {
        ByYear,
        ByQuantity,
        ByMass,
    }
}
