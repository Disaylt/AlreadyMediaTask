using MediatR;
using Microsoft.Extensions.Logging;
using NasaAsteroid.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.DomainEventHandlers
{
    internal class NewAsteroidCoordinatesNotificationEventHandler : INotificationHandler<NewAsteroidCoordinatesEvent>
    {
        public ILogger<NewAsteroidCoordinatesNotificationEventHandler> _logger;

        public NewAsteroidCoordinatesNotificationEventHandler(ILogger<NewAsteroidCoordinatesNotificationEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(NewAsteroidCoordinatesEvent notification, CancellationToken cancellationToken)
        {
            string oldValueView = JsonSerializer.Serialize(notification.OldValue);
            string newValueView = JsonSerializer.Serialize(notification.NewValue);

            _logger.LogInformation($"Update cooridnates for asteroid id:{notification.Id}. Old value - {oldValueView}, new value - {newValueView}");

            return Task.CompletedTask;
        }
    }
}
