using System;

namespace OnlineFoodOrderingSystem.OrderMicroservice.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException() : base()
        {
        }

        public ServiceException(string message) : base(message)
        {
        }

        public ServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class NotFoundException : ServiceException
    {
        public NotFoundException() : base()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
