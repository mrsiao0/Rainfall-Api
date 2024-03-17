using System.Text.Json.Serialization;

namespace Rainfall.Api.Domain.ViewModel
{
    public class StationInfo
    {
        [JsonPropertyName("@id")]
        public string Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Measure { get; set; }
        public double Value { get; set; }
    }
}
