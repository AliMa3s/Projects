using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    public class StraatServiceException : Exception
    {
        public StraatServiceException(string message) : base(message)
        {
        }

        public StraatServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
