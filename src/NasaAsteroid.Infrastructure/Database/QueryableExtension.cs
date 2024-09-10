using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Infrastructure.Database
{
    internal static class QueryableExtension
    {
        public static IQueryable<T> OrderBy<T, TKey>(this IQueryable<T> queryable, Expression<Func<T, TKey>> expression, bool asDesc)
        {
            if (asDesc)
            {
                return queryable.OrderByDescending(expression);
            }

            return queryable.OrderBy(expression);
        }
    }
}
