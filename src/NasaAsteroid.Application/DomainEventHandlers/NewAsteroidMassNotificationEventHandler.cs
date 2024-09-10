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
    public class NewAsteroidMassNotificationEventHandler : INotificationHandler<NewAsteroidMassEvent>
    {
        public ILogger<NewAsteroidMassNotificationEventHandler> _logger;

        public NewAsteroidMassNotificationEventHandler(ILogger<NewAsteroidMassNotificationEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(NewAsteroidMassEvent notification, CancellationToken cancellationToken)
        {
            string oldValueView = JsonSerializer.Serialize(notification.OldValue);
            string newValueView = JsonSerializer.Serialize(notification.NewValue);

            _logger.LogInformation($"Update mass for asteroid id:{notification.Id}. Old value - {oldValueView}, new value - {newValueView}");

            return Task.CompletedTask;
        }
    }
}
