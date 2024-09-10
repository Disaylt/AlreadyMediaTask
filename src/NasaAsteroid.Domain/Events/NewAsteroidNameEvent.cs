using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Domain.Events
{
    public class NewAsteroidNameEvent : BaseAsteroidEvent
    {
        public string OldValue { get; }
        public string NewValue { get; }
        public NewAsteroidNameEvent(string oldValue, string newValue, int id) : base(id)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
