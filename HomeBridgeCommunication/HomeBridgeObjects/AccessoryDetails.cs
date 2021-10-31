using System.Collections.Generic;

using Newtonsoft.Json;

namespace HomeBridgeCommunication.HomeBridgeObjects
{
    public class AccessoryDetails
    {
        [JsonProperty("accessoryInformation")]
        public AccessoryInformation AccessoryInformation { get; set; }

        [JsonProperty("aid")]
        public int Aid { get; set; }

        [JsonProperty("humanType")]
        public string HumanType { get; set; }

        [JsonProperty("iid")]
        public int Iid { get; set; }

        [JsonProperty("instance")]
        public Instance Instance { get; set; }

        [JsonProperty("linked")]
        public IList<int> Linked { get; set; }

        [JsonProperty("serviceCharacteristics")]
        public IList<ServiceCharacteristic> ServiceCharacteristics { get; set; }

        [JsonProperty("serviceName")]
        public string ServiceName { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("uniqueId")]
        public string UniqueId { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("values")]
        public Values Values { get; set; }
    }
}