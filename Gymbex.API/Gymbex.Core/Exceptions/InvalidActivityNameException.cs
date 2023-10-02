using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Exceptions
{
    internal class InvalidActivityNameException : CustomException
    {
        public InvalidActivityNameException() 
            : base($"Activity name is empty.")
        {
        }
    }
}
