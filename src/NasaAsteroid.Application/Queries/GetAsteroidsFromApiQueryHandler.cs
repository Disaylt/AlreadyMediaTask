using MediatR;
using NasaAsteroid.Application.HttpClients;
using NasaAsteroid.Application.Models;
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

        public GetAsteroidsFromApiQueryHandler(INasaAsteroidHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AsteroidDto>> Handle(GetAsteroidsFromApiQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<AsteroidWebModel> webAsteroids = await _httpClient.GetRangeAsync();
            throw new NotImplementedException();
        }
    }
}
