using YAB.Plugins.Injectables.Options;

namespace HomeBridgePlugin.Options
{
    public class HomeBridgeOptions : Options<HomeBridgeOptions>
    {
        [PropertyDescription(false, "This is how often this plugin should contact the HomeBridge instance to check if accessories changed their values (in seconds).")]
        public int HomeBridgeChangeDetectorFrequencyInSeconds { get; set; }

        [PropertyDescription(false, "This is the Port listed in HomeBridge.")]
        public string HomeBridgeHostPort { get; set; }

        [PropertyDescription(false, "This is the URL under which HomeBridge is hosted (and can be accessed).")]
        public string HomeBridgeHostUrl { get; set; }

        [PropertyDescription(true, "This is the password you use to log into homebridge with.")]
        public string HomeBridgePassword { get; set; }

        [PropertyDescription(false, "This is the username you use to log into homebridge with.")]
        public string HomeBridgeUserName { get; set; }
    }
}