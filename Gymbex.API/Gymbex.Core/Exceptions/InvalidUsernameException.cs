using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Exceptions
{
    internal sealed class InvalidUsernameException : CustomException
    {
        public InvalidUsernameException(string username) 
            : base($"This username: {username} is incorrect.")
        {
        }

        public InvalidUsernameException()
            :base($"Username is empty.")
        {
            
        }
    }
}
