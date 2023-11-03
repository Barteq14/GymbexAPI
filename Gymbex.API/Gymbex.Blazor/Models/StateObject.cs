namespace Gymbex.Blazor.Models
{
    public class StateObject<T>
    {
        public T StateModel { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
    }
}
