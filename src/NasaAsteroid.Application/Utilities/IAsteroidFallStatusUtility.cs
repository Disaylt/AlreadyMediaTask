using NasaAsteroid.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Utilities
{
    public interface IAsteroidFallStatusUtility
    {
        FallStatus Convert(string fallStatus);
    }
}
