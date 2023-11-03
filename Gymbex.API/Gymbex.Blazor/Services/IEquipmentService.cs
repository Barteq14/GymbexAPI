using Gymbex.Blazor.Models;

namespace Gymbex.Blazor.Services
{
    public interface IEquipmentService
    {
        Task<StateObject<List<EquipmentDto>>> GetEquipments();
    }
}
