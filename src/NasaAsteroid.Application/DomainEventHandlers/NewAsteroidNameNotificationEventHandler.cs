using MediatR;
using Microsoft.Extensions.Logging;
using NasaAsteroid.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.DomainEventHandlers
{
    internal class NewAsteroidNameNotificationEventHandler : INotificationHandler<NewAsteroidNameEvent>
    {
        public ILogger<NewAsteroidNameNotificationEventHandler> _logger;

        public NewAsteroidNameNotificationEventHandler(ILogger<NewAsteroidNameNotificationEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(NewAsteroidNameEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Update name for asteroid id:{notification.Id}. Old value - {notification.OldValue}, new value - {notification.NewValue}");

            return Task.CompletedTask;
        }
    }
}
