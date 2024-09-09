using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Models
{
    public class AsteroidWebModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("nametype")]
        public string Nametype { get; set; } = string.Empty;

        [JsonPropertyName("recclass")]
        public string Recclass { get; set; } = string.Empty;

        [JsonPropertyName("mass")]
        public string? Mass { get; set; }

        [JsonPropertyName("fall")]
        public string Fall { get; set; } = string.Empty;

        [JsonPropertyName("year")]
        public DateTime Year { get; set; }

        [JsonPropertyName("reclat")]
        public string? Reclat { get; set; }

        [JsonPropertyName("reclong")]
        public string? Reclong { get; set; }

        [JsonPropertyName("geolocation")]
        public Geolocation? Geolocation { get; set; }
    }

    public class Geolocation
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
