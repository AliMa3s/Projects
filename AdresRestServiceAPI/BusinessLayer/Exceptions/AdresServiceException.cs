using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    public class AdresServiceException : Exception
    {
        public AdresServiceException(string message) : base(message)
        {
        }

        public AdresServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
