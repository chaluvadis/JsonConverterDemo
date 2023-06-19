using System.Text.Json;
using System.Text.Json.Serialization;
namespace CustomConverter;
public class NullToEmptyArrayConverter<T> : JsonConverter<List<T>> where T : class
{
    public override bool HandleNull => true;
    public override List<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => throw new NotImplementedException();
    public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteStartArray();
            writer.WriteEndArray();
        }
        else
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}