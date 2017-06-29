using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace testXamarin.Provider
{
    class JsonProvider
    {
        public static string FormatJson(string json)
        {
            var parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }
    }
}
