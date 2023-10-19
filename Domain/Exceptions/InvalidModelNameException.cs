using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidModelNameException : Exception
    {
        public InvalidModelNameException() { }
        public InvalidModelNameException(string message) : base(message) { }
        public InvalidModelNameException(string message, Exception inner) : base(message, inner) { }
        protected InvalidModelNameException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
