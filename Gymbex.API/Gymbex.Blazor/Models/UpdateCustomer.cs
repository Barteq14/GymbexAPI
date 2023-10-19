namespace Gymbex.Blazor.Models
{
    public class UpdateCustomer
    {
        public Guid CustomerId { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
    }
}
