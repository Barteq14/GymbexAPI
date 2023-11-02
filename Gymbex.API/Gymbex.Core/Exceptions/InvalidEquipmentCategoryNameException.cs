using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Exceptions
{
    public sealed class InvalidEquipmentCategoryNameException : CustomException
    {
        public InvalidEquipmentCategoryNameException() 
            : base($"Equipment category name was empty.")
        {
        }
    }
}
