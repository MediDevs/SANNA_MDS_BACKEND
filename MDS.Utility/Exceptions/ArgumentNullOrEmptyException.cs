using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Utility.Exceptions
{
    public class ArgumentNullOrEmptyException : Exception
    {
        public ArgumentNullOrEmptyException(string parameter)
            : base("Value cannot be null or empty. Parameter name: " + parameter)
        {
        }

        public ArgumentNullOrEmptyException(string parameter, string message)
            : base("Value cannot be null or empty. Parameter name: " + parameter + ". " + message)
        {
        }
    }
}
