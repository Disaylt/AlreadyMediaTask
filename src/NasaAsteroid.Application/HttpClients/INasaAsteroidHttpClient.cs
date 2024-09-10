using NasaAsteroid.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.HttpClients
{
    public interface INasaAsteroidHttpClient
    {
        Task<IReadOnlyCollection<AsteroidWebModel>> GetRangeAsync();
    }
}
