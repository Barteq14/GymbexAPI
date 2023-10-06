using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Application.Dtos;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Application.Queries.Customers
{
    public sealed class GetCustomer : IQuery<CustomerDto>
    {
        public CustomerId Id { get; set; }
    }
}
