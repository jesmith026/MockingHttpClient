using System;

namespace ApiCaller
{
    public class ServiceFailedException : Exception
    {
        public ServiceFailedException()
            : base("Service failure") { }

        public ServiceFailedException(Exception exception)
            : base("Service Failure", exception) { }
    }
}