using MediatR;
using NasaAsteroid.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Commands
{
    public class AddOrUpdateAsteroidsCommand : IRequest<Unit>
    {
        public IEnumerable<AsteroidDto> Asteroids { get; set; } = Enumerable.Empty<AsteroidDto>();
    }
}
