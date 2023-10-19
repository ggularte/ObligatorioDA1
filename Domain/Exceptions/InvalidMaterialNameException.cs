using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidMaterialNameException : Exception
    {
        public InvalidMaterialNameException() { }
        public InvalidMaterialNameException(string message) : base(message) { }
        public InvalidMaterialNameException(string message, Exception inner) : base(message, inner) { }
        protected InvalidMaterialNameException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
