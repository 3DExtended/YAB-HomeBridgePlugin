using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HomeBridgeCommunication.HomeBridgeObjects
{
    public class Service
    {
        [JsonPropertyName("characteristics")]
        public List<Characteristic> Characteristics { get; } = new List<Characteristic>();

        [JsonPropertyName("iid")]
        public int Iid { get; set; }

        [JsonPropertyName("linked")]
        public List<int> Linked { get; } = new List<int>();

        [JsonPropertyName("primary")]
        public bool? Primary { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}