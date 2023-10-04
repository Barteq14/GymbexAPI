using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Exceptions
{
    internal sealed class InvalidFullnameException : CustomException
    {
        public InvalidFullnameException(string fullname) 
            : base($"This fullname: {fullname} is incorrect.")
        {
        }

        public InvalidFullnameException()
            :base($"Fullname is empty.")
        {
            
        }
    }
}
