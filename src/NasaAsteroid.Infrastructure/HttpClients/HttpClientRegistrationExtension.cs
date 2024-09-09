using Microsoft.Extensions.DependencyInjection;
using NasaAsteroid.Application.HttpClients;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Infrastructure.HttpClients
{
    internal static class HttpClientRegistrationExtension
    {
        public static void AddOwnHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient<INasaAsteroidHttpClient, NasaAsteroidHttpClient>()
                .AddTransientHttpErrorPolicy(policy =>
                    policy.WaitAndRetryAsync(new[]
                    {
                        TimeSpan.FromMilliseconds(500),
                        TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(5)
                    }));
        }
    }
}
