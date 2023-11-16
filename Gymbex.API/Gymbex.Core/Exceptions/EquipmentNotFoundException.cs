using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Exceptions
{
    public sealed class EquipmentNotFoundException : CustomException
    {
        public EquipmentNotFoundException(Guid id) 
            : base($"Equipment with id: {id} was not found.")
        {
        }
    }
}
