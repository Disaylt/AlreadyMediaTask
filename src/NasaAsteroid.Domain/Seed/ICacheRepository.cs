﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Domain.Seed
{
    public interface ICacheRepository<T> where T : class
    {
        Task<T?> GetAsync(string key);
        Task<IEnumerable<T>?> GetRangeAsync(string key);
        Task SetAsync(string key, T value, TimeSpan expire);
        Task SetRangeAsync(string key, IEnumerable<T> value, TimeSpan expire);
    }
}
