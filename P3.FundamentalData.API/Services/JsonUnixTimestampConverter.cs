using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
namespace P3.FundamentalData.API.Services
{
	public class JsonUnixTimestampConverter : DateTimeConverterBase
	{
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null)
				return null;

			if (reader.TokenType == JsonToken.Integer)
			{
				long timestamp = (long)reader.Value;
				return DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime;
			}

			throw new JsonException("Invalid timestamp format.");
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value is DateTime dateTime)
			{
				long timestamp = new DateTimeOffset(dateTime).ToUnixTimeSeconds();
				writer.WriteValue(timestamp);
			}
			else
			{
				writer.WriteNull();
			}
		}
	}
}
