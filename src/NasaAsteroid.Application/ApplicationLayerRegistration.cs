using Microsoft.Extensions.DependencyInjection;
using NasaAsteroid.Application.Behaviors;
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
            collection.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

                cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
                cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
            });
        }
    }
}
