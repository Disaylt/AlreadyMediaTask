using NasaAsteroid.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Domain.Events
{
    public class NewAsteroidNameTypeEvent : BaseAsteroidEvent
    {
        public NameType OldValue { get; }
        public NameType NewValue { get; }

        public NewAsteroidNameTypeEvent(NameType oldValue, NameType newValue, int id) : base(id)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
