using Gymbex.Blazor.ValueObjects;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gymbex.Blazor.Conventers
{
    public sealed class EmailConventer : JsonConverter<Email>
    {
        public override Email Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var emailValue = reader.GetString();
                return new Email(emailValue);
            }
            throw new JsonException("Invalid JSON for Email");
        }

        public override void Write(Utf8JsonWriter writer, Email value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Value);
        }
    }
}
