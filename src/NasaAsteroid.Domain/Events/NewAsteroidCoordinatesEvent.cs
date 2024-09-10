using MediatR;
using NasaAsteroid.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Domain.Events
{
    public class NewAsteroidCoordinatesEvent : BaseAsteroidEvent
    {
        public Coordinates OldValue { get; }
        public Coordinates NewValue { get; }

        public NewAsteroidCoordinatesEvent(Coordinates oldValue, Coordinates newValue, int id) : base(id)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
