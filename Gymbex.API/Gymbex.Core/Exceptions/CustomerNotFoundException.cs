using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Entities;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Core.Exceptions
{
    public sealed class CustomerNotFoundException : CustomException
    {
        public CustomerNotFoundException(CustomerId id) 
            : base($"Customer with id: {id} was not found.")
        {
        }
    }
}
