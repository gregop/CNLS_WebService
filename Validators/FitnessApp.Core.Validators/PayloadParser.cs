using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FitnessApp.Core.Validators
{
    public static class PayloadParser<T>
    {
        private static string? _payload;

        private static T? _parsedPayload;

        private static JsonSerializerOptions _options;
        public static OperationalResult<T?> TryParse(string payload)
        {
            try
            {
                if (payload == null) { throw new NullReferenceException(); }

                _payload = payload.Trim();

                _options = new JsonSerializerOptions();
                _options.Converters.Add(new DateTimeConverterUsingDateTimeParse());
                _parsedPayload = JsonSerializer.Deserialize<T>(_payload, _options);

                return OperationalResult<T?>.SuccessResult(_parsedPayload);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception at {MethodBase.GetCurrentMethod()} : {ex.Message}");
                return OperationalResult<T?>.FailureResult(ex);
            }
            
        }

    }

    /*
     * Serializer to perform custom parsing or formatting of Date Time input format
     * MS Documentation: 
     *      -> learn.microsoft.com/en-us/dotnet/standard/datetime/system-text-json-support
     *      #using-datetimeoffsetparse-and-datetimeoffsettostring
     */
    public class DateTimeConverterUsingDateTimeParse : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(DateTime));
            return DateTime.Parse(reader.GetString() ?? string.Empty);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
