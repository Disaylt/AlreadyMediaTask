using MediatR;
using Microsoft.Extensions.Logging;
using NasaAsteroid.Domain.Entities;
using NasaAsteroid.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.DomainEventHandlers
{
    public class NewAsteroidNotificationEventHandler : INotificationHandler<NewAsteroidEvent>
    {
        public ILogger<NewAsteroidNotificationEventHandler> _logger;

        public NewAsteroidNotificationEventHandler(ILogger<NewAsteroidNotificationEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(NewAsteroidEvent notification, CancellationToken cancellationToken)
        {
            string entityView = JsonSerializer.Serialize(notification.Entity);

            _logger.LogInformation($"Create new asteroid. {entityView}");

            return Task.CompletedTask;
        }
    }
}
