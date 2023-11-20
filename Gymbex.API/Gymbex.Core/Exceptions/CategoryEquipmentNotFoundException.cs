using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Exceptions
{
    public sealed class CategoryEquipmentNotFoundException : CustomException
    {
        public CategoryEquipmentNotFoundException(Guid id)
            : base($"Equipment category with id: {id} was not found.")
        {
        }
    }
}
