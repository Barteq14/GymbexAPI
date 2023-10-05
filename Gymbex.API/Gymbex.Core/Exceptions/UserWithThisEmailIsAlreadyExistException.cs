using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Exceptions
{
    public sealed class UserWithThisEmailIsAlreadyExistException : CustomException
    {
        public UserWithThisEmailIsAlreadyExistException(string email) 
            : base($"User with this email: {email} is already exist.")
        {
        }
    }
}
