using Microsoft.AspNetCore.Diagnostics;
using NasaAsteroid.Domain.Seed;
using NasaAsteroid.WebApi.Models;
using Polly;

namespace NasaAsteroid.WebApi.ExeptionHandlers
{
    public class ProdExeptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ErrorModel error = new ErrorModel
            {
                Type = exception.GetType().Name
            };

            if(exception is RootExeption rootExeption)
            {
                error.Status = (int)rootExeption.StatusCode;
                error.Title = "Service error";
                error.Errors = new Dictionary<string, IEnumerable<string>>
                {
                    {"Details", rootExeption.Messages }
                };
            }
            else
            {
                error.Status = 400;
                error.Title = "Unknown error";
                error.Errors = new Dictionary<string, IEnumerable<string>>
                {
                    {"Details", new [] { "Произошла ошибка на сервере, но я всё равно выдам 400. Ведь сервер хорошй, а ты нет ^-^" } }
                };
            }

            httpContext.Response.StatusCode = error.Status;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsJsonAsync(error);

            return true;
        }
    }
}
