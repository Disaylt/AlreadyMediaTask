using NasaAsteroid.Domain.Entities;
using NasaAsteroid.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Domain.Repositories
{
    public interface IAsteroidRepository : IRepository<Asteroid>
    {
        Task<Dictionary<int, Asteroid>> GetBusketAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
    }
}
