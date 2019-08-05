﻿using System;
using System.Buffers;
using System.Buffers.Text;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DateTimeConverterExamples
{
    // This converter reads and writes DateTime values according to the "R" standard format specifier:
    // https://docs.microsoft.com/dotnet/standard/base-types/standard-date-and-time-format-strings#the-rfc1123-r-r-format-specifier.
    public class DateTimeConverterForCustomStandardFormatR : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // When implementing JsonConverter<DateTime>, typeToConvert will always be typeof(DateTime).
            // The parameter is useful for polymorphic cases and when using generics to get typeof(T) in a performant way.
            Debug.Assert(typeToConvert == typeof(DateTime));

            if (Utf8Parser.TryParse(reader.ValueSpan, out DateTime value, out _, 'R'))
            {
                return value;
            }

            throw new FormatException();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            // The R standard format will always be 29 bytes.
            Span<byte> utf8Date = new byte[29];

            bool result = Utf8Formatter.TryFormat(value, utf8Date, out _, new StandardFormat('R'));
            Debug.Assert(result);

            writer.WriteStringValue(utf8Date);
        }
    }

    class Program
    {
        private static void ParseDateTimeWithDefaultOptions()
        {
            var _ = JsonSerializer.Deserialize<DateTime>(@"""Thu, 25 Jul 2019 13:36:07 GMT""");
            // Throws JsonException.
        }

        private static void ProcessDateTimeWithCustomConverter()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new DateTimeConverterForCustomStandardFormatR());

            var testDateTimeStr = "Thu, 25 Jul 2019 13:36:07 GMT";
            var testDateTimeJson = @"""" + testDateTimeStr + @"""";

            var resultDateTime = JsonSerializer.Deserialize<DateTime>(testDateTimeJson, options);
            Console.WriteLine(resultDateTime);
            // 7/25/2019 1:36:07 PM

            Console.WriteLine(JsonSerializer.Serialize(DateTime.Parse(testDateTimeStr), options));
            // "Thu, 25 Jul 2019 09:36:07 GMT"
        }

        static void Main(string[] args)
        {
            // Parsing non-compliant format as DateTime fails by default.
            try
            {
                ParseDateTimeWithDefaultOptions();
            }
            catch (JsonException e)
            {
                Console.WriteLine(e.Message);
                // The JSON value could not be converted to System.DateTime. Path: $ | LineNumber: 0 | BytePositionInLine: 31.
            }

            // Using converters gives you control over the serializers parsing and formatting.
            ProcessDateTimeWithCustomConverter();
        }
    }
}

// The example displays the following output:
// The JSON value could not be converted to System.DateTime.Path: $ | LineNumber: 0 | BytePositionInLine: 31.
// 7/25/2019 1:36:07 PM
// "Thu, 25 Jul 2019 09:36:07 GMT"
