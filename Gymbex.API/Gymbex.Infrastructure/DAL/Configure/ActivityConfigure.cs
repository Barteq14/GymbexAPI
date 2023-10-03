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
    public class ActivityConfigure : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .HasConversion(x => x.Id, c => new ActivityId(c));
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30)
                .HasConversion(x => x.Name, c => new ActivityName(c));
            builder.Property(x => x.Date)
                .HasConversion(x => x.Value, c => new Date(c));
        }
    }
}
