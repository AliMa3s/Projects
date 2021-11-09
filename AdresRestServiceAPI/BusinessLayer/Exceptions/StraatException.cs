using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    public class StraatException : Exception
    {
        public StraatException(string message) : base(message)
        {
        }

        public StraatException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
