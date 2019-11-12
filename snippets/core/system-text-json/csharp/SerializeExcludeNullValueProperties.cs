﻿using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace SystemTextJsonSamples
{
    class SerializeExcludeNullValueProperties
    {
        public static void Run()
        {
            string jsonString;
            var weatherForecast = WeatherForecastFactories.CreateWeatherForecast();
            weatherForecast.Summary = null;
            weatherForecast.DisplayPropertyValues();

            // <SnippetSerialize>
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </SnippetSerialize>
            Console.WriteLine(jsonString);
            Console.WriteLine();
        }
    }
}