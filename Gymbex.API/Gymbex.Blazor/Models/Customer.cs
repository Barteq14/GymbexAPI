namespace Gymbex.Blazor.Models
{
    public class CustomerRegisterModel
    {
        public Guid CustomerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public Guid? TicketId { get; set; }
    }
}
