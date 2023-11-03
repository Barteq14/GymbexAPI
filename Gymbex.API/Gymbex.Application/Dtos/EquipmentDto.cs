using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Application.Dtos
{
    public sealed class EquipmentDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EquipmentState { get; set; }
        public int Quantity { get; set; }
        public string CategoryName { get; set; }
    }
}
