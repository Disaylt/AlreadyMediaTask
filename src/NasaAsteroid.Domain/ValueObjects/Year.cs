using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Domain.ValueObjects
{
    public class Year : BaseValueObject
    {
        public int Value { get; }

        public Year(int value)
        {
            if (value > DateTime.UtcNow.Year) 
                throw new ArgumentException("Year discovered exceeds the current year");

            Value = value;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
