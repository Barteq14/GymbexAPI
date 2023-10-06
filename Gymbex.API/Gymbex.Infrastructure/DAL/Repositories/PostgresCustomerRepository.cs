using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Entities;
using Gymbex.Core.Repositories;
using Gymbex.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Gymbex.Infrastructure.DAL.Repositories
{
    public sealed class PostgresCustomerRepository : ICustomerRepository
    {
        private readonly GymbexDbContext _context;

        public PostgresCustomerRepository(GymbexDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetUserByIdAsync(CustomerId id)
            => await _context.Customers.SingleOrDefaultAsync(x => x.Id == id);


        public async Task<Customer> GetUserByEmailAsync(Email email)
            => await _context.Customers.SingleOrDefaultAsync(x => x.Email.Equals(email));

        public async Task<Customer> GetUserByUsernameAsync(Username username)
            => await _context.Customers.SingleOrDefaultAsync(x => x.Username.Equals(username));

        public async Task DeleteUserAsync(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
