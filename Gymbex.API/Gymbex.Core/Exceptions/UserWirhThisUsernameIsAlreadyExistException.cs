using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Exceptions
{
    public sealed class UserWirhThisUsernameIsAlreadyExistException : CustomException
    {
        public UserWirhThisUsernameIsAlreadyExistException(string username) 
            : base($"User with this username: {username} is already exist.")
        {
        }
    }
}
