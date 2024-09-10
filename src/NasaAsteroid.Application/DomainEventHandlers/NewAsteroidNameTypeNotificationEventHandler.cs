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
    public class NewAsteroidNameTypeNotificationEventHandler : INotificationHandler<NewAsteroidNameTypeEvent>
    {
        public ILogger<NewAsteroidNameTypeNotificationEventHandler> _logger;

        public NewAsteroidNameTypeNotificationEventHandler(ILogger<NewAsteroidNameTypeNotificationEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(NewAsteroidNameTypeEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Update name type for asteroid id:{notification.Id}. Old value - {notification.OldValue}, new value - {notification.NewValue}");

            return Task.CompletedTask;
        }
    }
}
