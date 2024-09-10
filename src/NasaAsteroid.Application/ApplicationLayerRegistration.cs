using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NasaAsteroid.Application.Behaviors;
using NasaAsteroid.Application.Services;
using NasaAsteroid.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application
{
    public static class ApplicationLayerRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection collection)
        {
            collection.AddApplicationServices();
            collection.AddUtilities();

            collection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            collection.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

                cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
                cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
            });
        }
    }
}
