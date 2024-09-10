using MediatR;
using NasaAsteroid.Application.Commands;
using NasaAsteroid.Application.Models;
using NasaAsteroid.Application.Queries;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Processor.Jobs
{
    [DisallowConcurrentExecution]
    internal class AsteroidsUplodingJob : IJob
    {
        private readonly IMediator _mediator;

        public AsteroidsUplodingJob(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            GetAsteroidsFromApiQuery query = new GetAsteroidsFromApiQuery();
            IEnumerable<AsteroidDto> asteroids = await _mediator.Send(query);

            AddOrUpdateAsteroidsCommand command = new AddOrUpdateAsteroidsCommand { Asteroids = asteroids };
            await _mediator.Send(command);
        }
    }
}
