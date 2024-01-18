using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ztp.Shared.Abstractions.Shared;

public class PositiveAmount
{
    private PositiveAmount() { }

    public PositiveAmount(decimal value)
    {
        if (value < 0m)
            throw new ArgumentOutOfRangeException(nameof(value), value, $"The value '{value}' is a negative value.");
        Value = value;
    }
    
    [JsonConverter(typeof(StringToDecimalConverter))]
    public decimal Value { get; private set; }

    public override string ToString()
    {
        return Value.ToString(CultureInfo.InvariantCulture);
    }
    
    public static implicit operator decimal(PositiveAmount value) => value.Value;
    public static implicit operator PositiveAmount(decimal value) => new(value);
}

public class StringToDecimalConverter : JsonConverter<decimal>
{
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string stringValue = reader.GetString();
            if (decimal.TryParse(stringValue, out decimal value))
            {
                return value;
            }
        }
        throw new JsonException("Unable to convert the JSON string to decimal.");
    }

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}