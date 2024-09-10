using MediatR;
using NasaAsteroid.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Domain.Events
{
    public class NewAsteroidEvent : INotification
    {
        public Asteroid Entity { get; }

        public NewAsteroidEvent(Asteroid entity) {  Entity = entity; }
    }
}
