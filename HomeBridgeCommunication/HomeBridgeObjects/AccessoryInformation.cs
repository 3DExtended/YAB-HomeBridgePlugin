using Newtonsoft.Json;

namespace HomeBridgeCommunication.HomeBridgeObjects
{
    public class AccessoryInformation
    {
        [JsonProperty("Firmware Revision")]
        public string FirmwareRevision { get; set; }

        [JsonProperty("Manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty("Model")]
        public string Model { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Serial Number")]
        public string SerialNumber { get; set; }
    }
}