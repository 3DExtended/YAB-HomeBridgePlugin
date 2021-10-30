using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HomeBridgeCommunication.HomeBridgeObjects
{
    public class Accessory
    {
        [JsonPropertyName("aid")]
        public int Aid { get; set; }

        [JsonPropertyName("services")]
        public List<Service> Services { get; } = new List<Service>();
    }
}