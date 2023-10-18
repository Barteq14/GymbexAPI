namespace Gymbex.Blazor.ValueObjects
{
    public sealed record Email
    {
        public string Value { get; }

        public Email(string value)
        {
            Value = value;
        }

        public static implicit operator Email(string value) => new Email(value); 
        public static implicit operator string(Email value) => value.Value;
    }
}
