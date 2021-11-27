using YAB.Core.Events;
using YAB.Plugins.Injectables.Options;

namespace HomeBridgePlugin.Events
{
    [ClassDescription("This event is fired whenever an accessory in HomeBridge changed values.")]
    public class HomeBridgeAccessoryValueChangedEvent : EventBase
    {
        [PropertyDescription(false, "The name of the accessory that updated.")]
        public string AccessoryName { get; set; }

        [PropertyDescription(false, "The Unique Id of the accessory that updated.")]
        public string AccessoryUniqueId { get; set; }

        [PropertyDescription(false, "The characteristic type of the accessory that updated.")]
        public string CharacteristicType { get; set; }

        [PropertyDescription(false, "The new value of that characteristic on that accessory.")]
        public string NewValue { get; set; }
    }
}