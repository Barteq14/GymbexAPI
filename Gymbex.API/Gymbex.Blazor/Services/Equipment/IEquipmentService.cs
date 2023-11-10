using Gymbex.Blazor.Models;

namespace Gymbex.Blazor.Services.Equipment
{
    public interface IEquipmentService
    {
        Task<StateObject<List<EquipmentDto>>> GetEquipments();
    }
}
