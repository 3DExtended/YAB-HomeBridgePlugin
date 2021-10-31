using System.Collections.Generic;

using Newtonsoft.Json;

namespace HomeBridgeCommunication.HomeBridgeObjects
{
    public class ServiceCharacteristic
    {
        [JsonProperty("aid")]
        public int Aid { get; set; }

        [JsonProperty("canRead")]
        public bool CanRead { get; set; }

        [JsonProperty("canWrite")]
        public bool CanWrite { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("ev")]
        public bool Ev { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("iid")]
        public int Iid { get; set; }

        [JsonProperty("maxValue")]
        public int? MaxValue { get; set; }

        [JsonProperty("minStep")]
        public int? MinStep { get; set; }

        [JsonProperty("minValue")]
        public int? MinValue { get; set; }

        [JsonProperty("perms")]
        public IList<string> Perms { get; set; }

        [JsonProperty("serviceName")]
        public string ServiceName { get; set; }

        [JsonProperty("serviceType")]
        public string ServiceType { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }
    }
}