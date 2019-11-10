﻿using System.Text.Json;

namespace SystemTextJsonSamples
{
    class UpperCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return name.ToUpper();
        }
    }
}
