using NasaAsteroid.Application.HttpClients;
using NasaAsteroid.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Infrastructure.HttpClients
{
    internal class NasaAsteroidHttpClient : INasaAsteroidHttpClient
    {
        private readonly HttpClient _httpClient;

        public NasaAsteroidHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://data.nasa.gov");
        }

        public virtual async Task<IReadOnlyCollection<AsteroidWebModel>> GetRangeAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("resource/y77d-th95.json");
            response.EnsureSuccessStatusCode();

            return await response.ReadFromJsonRequiredAsync<List<AsteroidWebModel>>();
        }
    }
}
