﻿using NasaAsteroid.Domain.Enums;
using NasaAsteroid.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Specifications
{
    public abstract class BaseAsteroidsSpecification : ISpecification
    {
        public int? FilterMinYear { get; set; }
        public int? FilterMaxYear { get; set; }
        public string? ClassType { get; set; }
        public string? NamePart { get; set; }
        public bool SortAsDesc { get; set; }
        public AsteroidSort Sort { get; set; } = AsteroidSort.Default;

        public virtual string GetMetaData()
        {
            return $"{FilterMinYear}|{FilterMaxYear}|{ClassType}|{NamePart}|{SortAsDesc}|{Sort}";
        }
    }
}
