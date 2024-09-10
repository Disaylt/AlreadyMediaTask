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
    public class NewAsteroidFallStatusNotificationEventHandler : INotificationHandler<NewAsteroidFallStatusEvent>
    {
        public ILogger<NewAsteroidFallStatusNotificationEventHandler> _logger;

        public NewAsteroidFallStatusNotificationEventHandler(ILogger<NewAsteroidFallStatusNotificationEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(NewAsteroidFallStatusEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Update fall status for asteroid id:{notification.Id}. Old value - {notification.OldValue}, new value - {notification.NewValue}");

            return Task.CompletedTask;
        }
    }
}
