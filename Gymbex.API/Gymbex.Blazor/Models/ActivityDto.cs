using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Gymbex.Blazor.Models
{
    public class ActivityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; } 
    }
}
