using YAB.Core.Events;

namespace HomeBridgePlugin.Events
{
    public class HomeBridgeAccessoryValueChangedEvent : EventBase
    {
        public string AccessoryName { get; set; }

        public string AccessoryUniqueId { get; set; }

        public string CharacteristicType { get; set; }

        public string NewValue { get; set; }
    }
}