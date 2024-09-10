using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NasaAsteroid.Application.Models;
using NasaAsteroid.Application.Queries;
using NasaAsteroid.Application.Specifications;

namespace NasaAsteroid.WebApi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsteroidsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AsteroidsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetAsteroidsSpecification queries)
        {
            GetAsteroidsQuery request = new GetAsteroidsQuery { Specification = queries };
            IEnumerable<AsteroidDto> asteroids = await _mediator.Send(request);

            return Ok(asteroids.Take(100));
        }
    }
}
