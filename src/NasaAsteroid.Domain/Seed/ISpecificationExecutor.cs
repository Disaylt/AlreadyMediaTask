using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Domain.Seed
{
    public interface ISpecificationExecutor<TSpecification, TRepsonse> 
        where TSpecification : ISpecification 
        where TRepsonse : class
    {
        Task<IEnumerable<TRepsonse>> ExecuteAsync(TSpecification specification);
    }
}
