using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Thinscale_API_Framework.JsonHelper
{
    public static class JsonExtensions
    {
        public static readonly JsonSerializerSettings DefaultSettings = CreateSettings();

        public static JsonSerializerSettings CreateSettings()
        {
            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false,
                    ProcessDictionaryKeys = true
                }
            };

            var settings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            return settings;
        }

        public static string ToJson(this object value, JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(value, settings);
        }

        public static T FromJson<T>(this string json, JsonSerializerSettings settings)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json, settings);
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("Additional text encountered after finished reading JSON content"))
                {
                    throw new Exception($"Was not able to deserialize the following json: {json}");
                }
                throw;
            }
        }
    }
}

