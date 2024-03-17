using System.Text.Json;

namespace Rainfall.Api.Data.Helpers
{
    public static class JsonHelper
    {
        public static T DeserializeOrDefault<T>(string jsonString) where T : class 
        {
            try
            {
                if (String.IsNullOrWhiteSpace(jsonString))
                    return default(T);

                return JsonSerializer.Deserialize<T>(jsonString, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            catch (JsonException ex)
            {
                //Todo Logs here
                return default(T);
            }
            catch 
            {
                return default(T);
            }
        }
    }
}
