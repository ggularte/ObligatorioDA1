using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidFigureRadioException : Exception
    {
        public InvalidFigureRadioException() { }
        public InvalidFigureRadioException(string message) : base(message) { }
        public InvalidFigureRadioException(string message, Exception inner) : base(message, inner) { }
        protected InvalidFigureRadioException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
