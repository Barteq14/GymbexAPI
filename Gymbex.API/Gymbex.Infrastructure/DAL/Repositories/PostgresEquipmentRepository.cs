using Gymbex.Core.Entities;
using Gymbex.Core.Repositories;
using Gymbex.Core.ValueObjects.Equipmetn;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Infrastructure.DAL.Repositories
{
    public sealed class PostgresEquipmentRepository(GymbexDbContext gymbexDbContext) : IEquipmentRepository
    {
        public async Task CreateAsync(Equipment equipment)
        {
            await gymbexDbContext.Equipments.AddAsync(equipment);
            await gymbexDbContext.SaveChangesAsync();
        }

        public async Task<List<CategoryEquipment>> GetAllCategoriesAsync()
            => await gymbexDbContext.CategoriesEquipment.Include(x => x.Equipments).ToListAsync();

        public async Task<CategoryEquipment> GetCategoryAsync(Guid id)
            => await gymbexDbContext.CategoriesEquipment
                .Include(x => x.Equipments)
                .FirstOrDefaultAsync(x => x.Id == new CategoryEquipmentId(id));

        public async Task UpdateCategoryEquipmentAsync(CategoryEquipment category)
        {
            gymbexDbContext.Update(category);
            await gymbexDbContext.SaveChangesAsync();
        }
    }
}
