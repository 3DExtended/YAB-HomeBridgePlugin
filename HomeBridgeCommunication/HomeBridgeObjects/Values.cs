using Newtonsoft.Json;

namespace HomeBridgeCommunication.HomeBridgeObjects
{
    public class Values
    {
        [JsonProperty("CurrentDoorState")]
        public int? CurrentDoorState { get; set; }

        [JsonProperty("On")]
        public int? On { get; set; }

        [JsonProperty("ProgrammableSwitchEvent")]
        public object ProgrammableSwitchEvent { get; set; }

        [JsonProperty("ProgramMode")]
        public int? ProgramMode { get; set; }

        [JsonProperty("RemainingDuration")]
        public int? RemainingDuration { get; set; }

        [JsonProperty("ServiceLabelIndex")]
        public int? ServiceLabelIndex { get; set; }

        [JsonProperty("ServiceLabelNamespace")]
        public int? ServiceLabelNamespace { get; set; }

        [JsonProperty("StatusActive")]
        public int? StatusActive { get; set; }

        [JsonProperty("StatusFault")]
        public int? StatusFault { get; set; }

        [JsonProperty("Version")]
        public string Version { get; set; }
    }
}