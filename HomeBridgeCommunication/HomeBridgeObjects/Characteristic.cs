using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HomeBridgeCommunication.HomeBridgeObjects
{
    public class Characteristic
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("format")]
        public string Format { get; set; }

        [JsonPropertyName("iid")]
        public int Iid { get; set; }

        [JsonPropertyName("maxLen")]
        public int? MaxLen { get; set; }

        [JsonPropertyName("maxValue")]
        public int? MaxValue { get; set; }

        [JsonPropertyName("minStep")]
        public int? MinStep { get; set; }

        [JsonPropertyName("minValue")]
        public int? MinValue { get; set; }

        [JsonPropertyName("perms")]
        public List<string> Perms { get; } = new List<string>();

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        [JsonPropertyName("valid-values")]
        public List<int> ValidValues { get; } = new List<int>();

        [JsonPropertyName("value")]
        public object Value { get; set; }
    }
}