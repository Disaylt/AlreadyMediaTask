using MediatR;
using NasaAsteroid.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Queries
{
    public class GetAsteroidsFromApiQuery : IRequest<IEnumerable<AsteroidDto>>
    {

    }
}
