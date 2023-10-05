using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Entities;
using Gymbex.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymbex.Infrastructure.DAL.Configure
{
    internal sealed class CustomerConfigure : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .HasConversion(x => x.Id, c => new CustomerId(c));
            builder.Property(x => x.Username)
                .IsRequired()
                .HasConversion(x => x.Value, c => new Username(c));
            builder.Property(x => x.Password)
                .IsRequired()
                .HasConversion(x => x.Value, c => new Password(c));
            builder.Property(x => x.Email)
                .IsRequired()
                .HasConversion(x => x.Value, c => new Email(c));
            builder.Property(x => x.Fullname)
                .HasMaxLength(100)
                .HasConversion(x => x.Value, c => new Fullname(c));
            builder.Property(x => x.Role)
                .HasConversion(x => x.Value, c => new Role(c));
            builder.Property(x => x.PhoneNumber)
                .HasConversion(x => x.Value, c => new PhoneNumber(c));
        }
    }
}
