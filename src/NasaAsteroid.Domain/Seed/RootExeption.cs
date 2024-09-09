using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Domain.Seed
{
    public class RootExeption
    {
        public HttpStatusCode StatusCode { get; }
        public IEnumerable<string> Messages { get; }

        public RootExeption(HttpStatusCode statusCode, IEnumerable<string> messages)
        {
            StatusCode = statusCode;
            Messages = messages;
        }
    }
}
