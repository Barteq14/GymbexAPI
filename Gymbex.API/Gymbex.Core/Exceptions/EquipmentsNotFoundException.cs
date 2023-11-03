using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Exceptions
{
    public sealed class EquipmentsNotFoundException : CustomException
    {
        public EquipmentsNotFoundException() 
            : base($"Equipments were not found.")
        {
        }
    }
}
