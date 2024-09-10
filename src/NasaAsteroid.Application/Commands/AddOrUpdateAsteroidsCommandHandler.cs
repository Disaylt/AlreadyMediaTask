using MediatR;
using NasaAsteroid.Application.Models;
using NasaAsteroid.Application.Services;
using NasaAsteroid.Domain.Entities;
using NasaAsteroid.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Commands
{
    public class AddOrUpdateAsteroidsCommandHandler : IRequestHandler<AddOrUpdateAsteroidsCommand, Unit>
    {
        private readonly IAsteroidRepository _repository;
        private readonly IAsteroidService _service;
        private readonly IAsteroidRefreshFacade _refreshFacade;

        public AddOrUpdateAsteroidsCommandHandler(IAsteroidRepository repository,
            IAsteroidService asteroidService,
            IAsteroidRefreshFacade asteroidRefreshFacade)
        {
            _repository = repository;
            _service = asteroidService;
            _refreshFacade = asteroidRefreshFacade;
        }

        public async Task<Unit> Handle(AddOrUpdateAsteroidsCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<int> ids = request
               .Asteroids
               .Select(x => x.Id);

            Dictionary<int, Asteroid> asteroidBusket = await _repository.GetBucketAsync(ids, cancellationToken);

            foreach(AsteroidDto webAsteroid in request.Asteroids)
            {
                if(asteroidBusket.ContainsKey(webAsteroid.Id) == false)
                {
                    Asteroid newEntity = _service.Build(webAsteroid);
                    await _repository.AddAsync(newEntity, cancellationToken);
                    continue;
                }

                Asteroid entity = asteroidBusket[webAsteroid.Id];

                if(_refreshFacade.TryRefresh(entity, webAsteroid))
                {
                    await _repository.UpdateAsync(entity, cancellationToken);
                }
            }

            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
