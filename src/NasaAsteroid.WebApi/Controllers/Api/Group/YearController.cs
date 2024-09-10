using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NasaAsteroid.Application.Models;
using NasaAsteroid.Application.Queries;
using NasaAsteroid.Application.Specifications;

namespace NasaAsteroid.WebApi.Controllers.Api.Group
{
    [Route("api/asteroids/group/[controller]")]
    [ApiController]
    public class YearController : ControllerBase
    {
        private readonly IMediator _mediator;

        public YearController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetAsteroidsGroupYearSpecification queries)
        {
            GetAsteroidsByYearGroupQuery request = new GetAsteroidsByYearGroupQuery { Specification = queries };
            IEnumerable<AsteroidYearGroupDto> asteroids = await _mediator.Send(request);

            return Ok(asteroids);
        }
    }
}
