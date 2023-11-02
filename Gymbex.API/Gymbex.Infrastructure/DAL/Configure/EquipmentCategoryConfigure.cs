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
    public sealed class EquipmentCategoryConfigure : IEntityTypeConfiguration<CategoryEquipment>
    {
        public void Configure(EntityTypeBuilder<CategoryEquipment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x => x.Value, c => new EquipmentCategoryId(c));
            builder.Property(x => x.Name).HasConversion(x => x.Value, c => new EquipmentCategoryName(c));
            builder.Property(x => x.TotalQuantity).HasConversion(x => x.Value, c => new EquipmentCategoryTotalQuantity(c));
        }
    }
}
