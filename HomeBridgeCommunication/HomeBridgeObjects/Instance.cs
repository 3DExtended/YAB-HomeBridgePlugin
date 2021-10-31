using System.Collections.Generic;

using Newtonsoft.Json;

namespace HomeBridgeCommunication.HomeBridgeObjects
{
    public class Instance
    {
        [JsonProperty("connectionFailedCount")]
        public int ConnectionFailedCount { get; set; }

        [JsonProperty("ipAddress")]
        public string IpAddress { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("port")]
        public int Port { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }
}