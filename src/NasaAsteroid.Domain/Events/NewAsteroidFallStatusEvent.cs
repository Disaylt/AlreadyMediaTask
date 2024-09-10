using MediatR;
using NasaAsteroid.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Domain.Events
{
    public class NewAsteroidFallStatusEvent : BaseAsteroidEvent
    {
        public FallStatus OldValue { get; }
        public FallStatus NewValue { get; }

        public NewAsteroidFallStatusEvent(FallStatus oldValue, FallStatus newValue, int id) : base(id) 
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
