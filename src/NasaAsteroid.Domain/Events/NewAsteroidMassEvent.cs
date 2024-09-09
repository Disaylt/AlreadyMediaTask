using MediatR;
using NasaAsteroid.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Domain.Events
{
    public class NewAsteroidMassEvent : BaseAsteroidEvent
    {
        public Mass OldValue { get; }
        public Mass NewValue { get; }

        public NewAsteroidMassEvent(Mass oldValue, Mass newValue, int id) : base(id)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
