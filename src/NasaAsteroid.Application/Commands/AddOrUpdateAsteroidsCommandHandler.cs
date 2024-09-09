using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Commands
{
    public class AddOrUpdateAsteroidsCommandHandler : IRequestHandler<AddOrUpdateAsteroidsCommand, Unit>
    {
        public Task<Unit> Handle(AddOrUpdateAsteroidsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
