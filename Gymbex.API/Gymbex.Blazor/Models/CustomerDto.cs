namespace Gymbex.Blazor.Models
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //public Guid? TicketId { get; set; }
        public string TicketName { get; set; }
        public string Role { get; set; }

    }
}
