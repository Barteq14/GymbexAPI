using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Exceptions
{
    public sealed class InvalidEquipmentDescriptionException : CustomException
    {
        public InvalidEquipmentDescriptionException() 
            : base($"Description was empty.")
        {
        }
    }
}
