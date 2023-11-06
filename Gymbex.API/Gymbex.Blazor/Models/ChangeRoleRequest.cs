namespace Gymbex.Blazor.Models
{
    public class ChangeRoleRequest
    {
        public Guid CustomerId { get; set; }
        public string Role { get; set; }
    }
}
