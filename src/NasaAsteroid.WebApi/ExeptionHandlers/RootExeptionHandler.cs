using Microsoft.AspNetCore.Diagnostics;

namespace NasaAsteroid.WebApi.ExeptionHandlers
{
    public class RootExeptionHandler : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }
    }
}
