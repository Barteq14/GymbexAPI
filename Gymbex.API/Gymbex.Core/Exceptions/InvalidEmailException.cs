using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Exceptions
{
    internal sealed class InvalidEmailException : CustomException
    {
        public InvalidEmailException(string email) 
            : base($"This email: {email} is incorrect.")
        {
        }

        public InvalidEmailException()
            : base($"Email is empty.")
        {
            
        }
    }
}
