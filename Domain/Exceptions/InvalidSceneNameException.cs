using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidSceneNameException : Exception
    {
        public InvalidSceneNameException() { }
        public InvalidSceneNameException(string message) : base(message) { }
        public InvalidSceneNameException(string message, Exception inner) : base(message, inner) { }
        protected InvalidSceneNameException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
