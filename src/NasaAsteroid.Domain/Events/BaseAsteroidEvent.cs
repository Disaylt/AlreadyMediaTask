using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Domain.Events
{
    public abstract class BaseAsteroidEvent : INotification
    {
        public int Id { get; }

        public BaseAsteroidEvent(int id) {  Id = id; }
    }
}
