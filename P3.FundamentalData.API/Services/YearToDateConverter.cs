using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Globalization;

namespace P3.FundamentalData.API.Services
{
	public class YearToDateConverter : JsonConverter<DateTime>
	{
		public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			string input = (string)reader.Value;

			if (input.Contains("?"))
			{
				input = input.TrimEnd('?');
			}
			else if (input.Contains("\n"))
			{
				input= input.TrimEnd('\n');
			}

			if (DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
			{
				return parsedDate;
			}
			else if (DateTime.TryParseExact(input, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime yearOnlyDate))
			{
				return new DateTime(yearOnlyDate.Year, 1, 1);
			}
			else if (input.IsNullOrEmpty())
			{
				return new DateTime(1900, 01, 01);
				//return null;
			}
			
			else
			{
				throw new JsonSerializationException($"Invalid date format: {input}");
			}

		}

		public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}

