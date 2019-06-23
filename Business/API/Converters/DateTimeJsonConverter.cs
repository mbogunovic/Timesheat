using System;
using Newtonsoft.Json;

namespace TimeshEAT.Business.API.Converters
{
    public class DateTimeJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(DateTime) || objectType == typeof(DateTime?));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            if (reader.TokenType == JsonToken.Null)
                return null;

            var newSerializer = new JsonSerializer();

            var target = newSerializer.Deserialize<DateTime>(reader);

            target = TimeZoneInfo.ConvertTime(target, TimeZoneInfo.Local);

            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
