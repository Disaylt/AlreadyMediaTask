using MediatR;
using NasaAsteroid.Application.HttpClients;
using NasaAsteroid.Application.Models;
using NasaAsteroid.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Queries
{
    public class GetAsteroidsFromApiQueryHandler : IRequestHandler<GetAsteroidsFromApiQuery, IEnumerable<AsteroidDto>>
    {
        private readonly INasaAsteroidHttpClient _httpClient;
        private readonly IAsteroidMapper _asteroidMapper;

        public GetAsteroidsFromApiQueryHandler(INasaAsteroidHttpClient httpClient,
            IAsteroidMapper asteroidMapper)
        {
            _httpClient = httpClient;
            _asteroidMapper = asteroidMapper;
        }

        public async Task<IEnumerable<AsteroidDto>> Handle(GetAsteroidsFromApiQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<AsteroidWebModel> webAsteroids = await _httpClient.GetRangeAsync();

            return webAsteroids
                .Select(_asteroidMapper.FromWeb)
                .ToList();
        }
    }
}
