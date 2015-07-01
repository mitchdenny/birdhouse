using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
    public class NestClientException : Exception
    {
        public NestClientException() { }
        public NestClientException(string message, HttpResponseMessage response) : this(message)
        {
            this.Response = response;
        }
        public NestClientException(string message) : base(message) { }
        public NestClientException(string message, Exception inner) : base(message, inner) { }

        public HttpResponseMessage Response { get; private set; }
    }
}
