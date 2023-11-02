namespace Gymbex.Blazor.Models
{
    public class ReservationDto
    {
        public Guid ReservationId { get; set; }
        public string ActivityName { get; set; }
        public DateTime ActivityDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
