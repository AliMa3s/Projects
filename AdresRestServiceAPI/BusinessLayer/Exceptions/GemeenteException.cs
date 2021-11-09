using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    public class GemeenteException : Exception
    {
        public GemeenteException(string message) : base(message)
        {
        }

        public GemeenteException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
