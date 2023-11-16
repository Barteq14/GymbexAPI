using Gymbex.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Repositories
{
    public interface IEquipmentRepository
    {
        //equipments
        Task CreateAsync(Equipment equipment);
        Task UpdateAsync(Equipment equipment);
        Task<Equipment> GetByIdAsync(Guid id);
        Task DeleteAsync(Equipment equipment);

        //categories
        Task<List<CategoryEquipment>> GetAllCategoriesAsync();
        Task UpdateCategoryEquipmentAsync(CategoryEquipment category);
        Task<CategoryEquipment> GetCategoryAsync(Guid id);
    }
}
