using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Entities;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Core.Repositories
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task<Customer> GetUserById(CustomerId id);
        Task<Customer> GetUserByEmail(Email email);
        Task<Customer> GetUserByUsername(Username username);
    }
}
