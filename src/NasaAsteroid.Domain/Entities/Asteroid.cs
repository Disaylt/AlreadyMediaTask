using NasaAsteroid.Domain.Enums;
using NasaAsteroid.Domain.Events;
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
        public Year Year { get; private set; }
        public Coordinates Coordinates { get; private set; }
        public FallStatus FallStaus { get; private set; }
        public NameType NameType { get; private set; }
        public string ClassType { get; private set; }

        protected Asteroid()
        {

        }

        public Asteroid(
            int id,
            string name,
            Mass mass,
            Year year,
            Coordinates coordinates,
            FallStatus fall,
            NameType nameType,
            string classType) : this()
        {
            Id = id;
            Name = name;
            Mass = mass;
            Year = year;
            Coordinates = coordinates;
            NameType = nameType;
            FallStaus = fall;
            ClassType = classType;

            AddEvent(new NewAsteroidEvent(this));
        }

        public void SetName(string name)
        {
            AddEvent(new NewAsteroidNameEvent(Name, name, Id));

            Name = name;
        }

        public void SetMass(Mass mass)
        {
            AddEvent(new NewAsteroidMassEvent(Mass, mass, Id));

            Mass = mass;
        }

        public void SetCoordinates(Coordinates coordinates)
        {
            AddEvent(new NewAsteroidCoordinatesEvent(Coordinates, coordinates, Id));

            Coordinates = coordinates;
        }

        public void SetNameType(NameType nameType)
        {
            AddEvent(new NewAsteroidNameTypeEvent(NameType, nameType, Id));

            NameType = nameType;
        }

        public void SetFallStatus(FallStatus fall)
        {
            AddEvent(new NewAsteroidFallStatusEvent(FallStaus, fall, Id));

            FallStaus = fall;
        }

        public void SetClassType(string classType)
        {
            AddEvent(new NewAsteroidClassTypeEvent(ClassType, classType, Id));

            ClassType = classType;
        }

        public bool IsEqualsTo(double? mass,
            string name,
            decimal? reclat,
            decimal? reclong,
            FallStatus fallStatus,
            NameType nameType,
            string classType,
            int year)
        {
            return Mass.Equals(new Mass(mass))
                && Coordinates.Equals(new Coordinates(reclong, reclat))
                && Name.Equals(name)
                && NameType.Equals(nameType)
                && FallStaus.Equals(fallStatus)
                && ClassType.Equals(classType)
                && Year.Equals(new Year(year));
        }
    }
}
