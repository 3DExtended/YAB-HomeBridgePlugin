using YAB.Plugins.Injectables.Options;

namespace HomeBridgePlugin.Options
{
    public class HomeBridgeOptions : Options<HomeBridgeOptions>
    {
        [OptionPropertyDescription(false, "This is the Secret listed in HomeBridge (XXX-XX-XXX).")]
        public string HomeBridgeCode { get; set; }

        [OptionPropertyDescription(false, "This is the Port listed in HomeBridge.")]
        public string HomeBridgeHostPort { get; set; }

        [OptionPropertyDescription(false, "This is the URL under which HomeBridge is hosted (and can be accessed).")]
        public string HomeBridgeHostUrl { get; set; }
    }
}