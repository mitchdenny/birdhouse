using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
    public class NestClientException : Exception
    {
        public NestClientException() { }
        public NestClientException(string message) : base(message) { }
        public NestClientException(string message, Exception inner) : base(message, inner) { }
    }
}
