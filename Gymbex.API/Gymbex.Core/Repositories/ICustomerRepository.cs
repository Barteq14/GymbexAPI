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
        Task<Customer> GetUserByIdAsync(CustomerId id);
        Task<Customer> GetUserByEmailAsync(Email email);
        Task<Customer> GetUserByUsernameAsync(Username username);
        Task DeleteUserAsync(Customer customer);
        Task UpdateUserAsync(Customer customer);
        Task RemoveTicketAsync(Guid customerId);
    }
}
