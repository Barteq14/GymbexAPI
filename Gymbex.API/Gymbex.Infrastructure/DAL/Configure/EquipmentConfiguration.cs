using Gymbex.Core.Entities;
using Gymbex.Core.ValueObjects.Equipmetn;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Infrastructure.DAL.Configure
{
    public sealed class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x => x.Value, c => new EquipmentId(c));
            builder.Property(x => x.Name).HasConversion(x => x.Value, c => new EquipmentName(c));
            builder.Property(x => x.Description).HasConversion(x => x.Value, c => new EquipmentDescription(c));
            builder.Property(x => x.EquipmentState).HasConversion(x => x.Value, c => new EquipmentStateEnum(c));
            builder.Property(x => x.Quantity).HasConversion(x => x.Value, c => new EquipmentQuantity(c));
            builder.Property(x => x.CategoryEquipmentId).HasConversion(x => x.Value, c => new CategoryEquipmentId(c));
        }
    }
}
