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
    public class NewAsteroidClassTypeNotificationEventHandler : INotificationHandler<NewAsteroidClassTypeEvent>
    {
        public ILogger<NewAsteroidClassTypeNotificationEventHandler> _logger;

        public NewAsteroidClassTypeNotificationEventHandler(ILogger<NewAsteroidClassTypeNotificationEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(NewAsteroidClassTypeEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Update class type for asteroid id:{notification.Id}. Old value - {notification.OldValue}, new value - {notification.NewValue}");

            return Task.CompletedTask;
        }
    }
}
