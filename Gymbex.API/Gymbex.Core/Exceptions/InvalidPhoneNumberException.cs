using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Exceptions
{
    internal sealed class InvalidPhoneNumberException :CustomException

    {
        public InvalidPhoneNumberException(string phone) 
            : base($"This phone number: {phone} is incorrect.")
        {
        }

        public InvalidPhoneNumberException()
            :base($"Phone number is empty.")
        {
            
        }
    }
}
