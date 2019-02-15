using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cachet.NET
{
    public class NotFoundException : GeneralApiException
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public class UnauthorizedException : GeneralApiException
    {
        public UnauthorizedException()
        {
        }

        public UnauthorizedException(string message) : base(message)
        {
        }

        public UnauthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public class GeneralApiException : ApplicationException
    {
        public string ResponseStatus { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public GeneralApiException()
        {
        }

        public GeneralApiException(string message) : base(message)
        {
        }

        public GeneralApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GeneralApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
