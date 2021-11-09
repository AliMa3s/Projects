using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Exceptions
{
    public class GemeenteRepositoryException : Exception
    {
        public GemeenteRepositoryException(string message) : base(message)
        {
        }

        public GemeenteRepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
