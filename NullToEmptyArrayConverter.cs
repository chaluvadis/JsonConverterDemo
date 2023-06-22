using System.Text.Json;
using System.Text.Json.Serialization;
namespace CustomConverter;
public class NullToListConverter : JsonConverter<object>
{
    public override bool HandleNull => true;
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(List<>);
    }

    public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => throw new NotImplementedException();

    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteStartArray();
            writer.WriteEndArray();
        }
        else
        {
            var listType = value.GetType();
            var elementType = listType.GetGenericArguments().First();
            var serializer = JsonSerializer.Serialize(value, elementType, options);
            writer.WriteRawValue(serializer);
        }
    }
}