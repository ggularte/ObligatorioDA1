using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidMaterialDifuminatedException : Exception
    {
        public InvalidMaterialDifuminatedException() { }
        public InvalidMaterialDifuminatedException(string message) : base(message) { }
        public InvalidMaterialDifuminatedException(string message, Exception inner) : base(message, inner) { }
        protected InvalidMaterialDifuminatedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
