using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Exceptions
{
    internal sealed class InvalidPasswordException : CustomException
    {
        public InvalidPasswordException(string password) 
            : base($"This password: {password} is incorrect.")
        {
        }

        public InvalidPasswordException()
            :base($"Password is empty.")
        {
            
        }
    }
}
