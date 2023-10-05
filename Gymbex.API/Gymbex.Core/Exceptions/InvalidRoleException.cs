using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Core.Exceptions
{
    public sealed class InvalidRoleException : CustomException
    {
        public InvalidRoleException() 
            : base($"Role is empty.")
        {
        }
    }
}
