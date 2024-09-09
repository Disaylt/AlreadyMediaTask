using Microsoft.EntityFrameworkCore;
using NasaAsteroid.Domain.Entities;
using NasaAsteroid.Domain.Repositories;
using NasaAsteroid.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Infrastructure.Repositories
{
    internal class AsteroidRepository : GenericRepository<Asteroid>, IAsteroidRepository
    {
        public AsteroidRepository(AsteroidDbContext context) : base(context)
        {
        }

        public async Task<Dictionary<int, Asteroid>> GetBucketAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            return await _dbSet
                .Where(x => ids.Contains(x.Id))
                .ToDictionaryAsync(x => x.Id, x => x, cancellationToken);
        }
    }
}
