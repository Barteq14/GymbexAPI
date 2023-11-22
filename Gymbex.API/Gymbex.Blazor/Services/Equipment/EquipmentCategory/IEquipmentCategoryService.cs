using Gymbex.Blazor.Models;

namespace Gymbex.Blazor.Services.Equipment.EquipmentCategory
{
    public interface IEquipmentCategoryService
    {
        Task<StateObject<List<CategoryEquipmentDto>>> GetAllAsync();
    }
}
