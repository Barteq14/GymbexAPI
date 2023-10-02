using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Application.Dtos
{
    public sealed class ActivityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<CustomerDto> Customers { get; set; }    
    }
}
