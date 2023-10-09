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
    internal sealed class ReservationConfigure : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .HasConversion(x => x.Value, c => new ReservationId(c));
            builder.Property(x => x.ActivityId)
                .HasConversion(x => x.Id, c => new ActivityId(c));
            builder.Property(x => x.CustomerId)
                .HasConversion(x => x.Id, c => new CustomerId(c));
            builder.Property(x => x.CreatedAt)
                .HasConversion(x => x.Value, c => new Date(c));
        }
    }
}
