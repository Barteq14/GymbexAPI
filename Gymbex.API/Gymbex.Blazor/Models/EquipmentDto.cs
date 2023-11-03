namespace Gymbex.Blazor.Models
{
    public sealed class EquipmentDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EquipmentState { get; set; }
        public int Quantity { get; set; }
        public string CategoryName { get; set; }
    }
}
