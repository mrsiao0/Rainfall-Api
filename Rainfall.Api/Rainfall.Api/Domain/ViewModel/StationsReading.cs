using System.Text.Json.Serialization;

namespace Rainfall.Api.Domain.ViewModel
{
    public class StationsReading
    {
        [JsonPropertyName("@context")]
        public string Context { get; set; }
        public MetaInfo Meta { get; set; }
        public IEnumerable<StationInfo> Items { get; set; }
    }
}
