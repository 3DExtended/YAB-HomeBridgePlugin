using YAB.Core.EventReactor;
using YAB.Core.Events;
using YAB.Plugins.Injectables.Options;

namespace HomeBridgePlugin.EventReactors
{
    [ReactorConfigurationDescription("Updates an accessory characteristic. Use this to turn accessories on or off, or change target values.")]
    public class UpdateHomeBridgeAccessoryReactorConfiguration : IEventReactorConfiguration<UpdateHomeBridgeAccessoryReactor, EventBase>
    {
        [PropertyDescription(false, "This is the name of your accessory.")]
        public string AccessoryName { get; set; }

        [PropertyDescription(false, "This is the name of the characteristic you want to change.")]
        public string CharacteristicTypeName { get; set; }

        [PropertyDescription(false, "This is the value which you want to set on the accessory.")]
        public string ValueToSet { get; set; }
    }
}