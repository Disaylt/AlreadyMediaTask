using Microsoft.EntityFrameworkCore;
using NasaAsteroid.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Processor.Backgrounds
{
    public class AutoMigrationBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public AutoMigrationBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(TimeSpan.FromSeconds(5));

            using IServiceScope scope = _serviceProvider.CreateScope();

            await scope
                .ServiceProvider
                .GetRequiredService<AsteroidDbContext>()
                .Database
                .MigrateAsync(stoppingToken);
        }
    }
}
