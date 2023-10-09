using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Entities;
using Gymbex.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymbex.Infrastructure.DAL.Configure
{
    internal sealed class TicketConfigure : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .HasConversion(x => x.Value, c => new TicketId(c));
            //builder.Property(x => x.ImportantFrom)
            //    .IsRequired()
            //    .HasConversion(x => x.Value, c => new Date(c));
            //builder.Property(x => x.ImportantTo)
            //    .IsRequired()
            //    .HasConversion(x => x.Value, c => new Date(c));
        }
    }
}
