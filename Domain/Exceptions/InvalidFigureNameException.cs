using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidFigureNameException : Exception
    {
        public InvalidFigureNameException() { }
        public InvalidFigureNameException(string message) : base(message) { }
        public InvalidFigureNameException(string message, Exception inner) : base(message, inner) { }
        protected InvalidFigureNameException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
