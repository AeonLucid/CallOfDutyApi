using System;
using System.Runtime.Serialization;

namespace CallOfDutyApi.Exceptions
{
    public class CallOfDutyException : Exception
    {
        public CallOfDutyException()
        {
        }

        protected CallOfDutyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public CallOfDutyException(string message) : base(message)
        {
        }

        public CallOfDutyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
