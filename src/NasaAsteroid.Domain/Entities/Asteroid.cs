using NasaAsteroid.Domain.Enums;
using NasaAsteroid.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Domain.Entities
{
    public class Asteroid : BaseEntity
    {
        public string Name { get; private set; }
        public Mass Mass { get; private set; }
        public DateOnly Year { get; private set; }
        public Coordinates Coordinates { get; private set; }
        public FallStatus FallStaus { get; private set; }
        public NameType NameType { get; private set; }
        public string RecClass { get; private set; }

        protected Asteroid()
        {

        }

        public Asteroid(
            int id,
            string name,
            Mass mass,
            DateOnly year,
            Coordinates coordinates,
            FallStatus fall,
            NameType nameType,
            string recClass) : this()
        {
            Id = id;
            Name = name;
            Mass = mass;
            Year = year;
            Coordinates = coordinates;
            NameType = nameType;
            FallStaus = fall;
            RecClass = recClass;
        }


    }
}
