using NasaAsteroid.Application.Models;
using NasaAsteroid.Application.Services.RefreshOperations;
using NasaAsteroid.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Services
{
    public class AsteroidRefreshFacade : IAsteroidRefreshFacade
    {
        private readonly IEnumerable<IAsteroidRefreshValueOperation> _operations;

        public AsteroidRefreshFacade(IEnumerable<IAsteroidRefreshValueOperation> operations)
        {
            _operations = operations;
        }

        public virtual bool TryRefresh(Asteroid entity, AsteroidDto data)
        {
            List<bool> results = new List<bool>();

            foreach (var operation in _operations)
            {
                bool operationResult = operation.TryRefreshValue(entity, data);
                results.Add(operationResult);
            }

            return results.Any(r => r is true);
        }
    }
}
