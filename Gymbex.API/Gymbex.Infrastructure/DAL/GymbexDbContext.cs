using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gymbex.Infrastructure.DAL
{
    public sealed class GymbexDbContext : DbContext
    {
        public GymbexDbContext(DbContextOptions<GymbexDbContext> options) : base(options)
        {
            
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
