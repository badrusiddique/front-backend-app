using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Sample.Common.Extensions
{
    public static class JsonCovertExtension
    {
        public static string SerializeObject(object value) =>
            JsonConvert.SerializeObject(value, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), NullValueHandling = NullValueHandling.Ignore });
    }
}