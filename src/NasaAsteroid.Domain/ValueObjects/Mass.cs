using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Domain.ValueObjects
{
    public class Mass : BaseValueObject
    {
        public double? Value { get; private set; }

        public Mass(double? value)
        {
            if (value.HasValue && value <= 0)
            {
                throw new ArgumentException("Mass cannot be less than 0");
            }

            Value = value;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
