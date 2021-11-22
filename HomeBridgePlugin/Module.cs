using System;
using System.Linq;

using HomeBridgeCommunication;

using HomeBridgePlugin.Options;

using YAB.Core.EventReactor;
using YAB.Core.Events;
using YAB.Core.FilterExtension;
using YAB.Plugins;
using YAB.Plugins.Injectables.Options;

namespace HomeBridgePlugin
{
    public class Module : IPluginModule
    {
        public static YAB.Plugins.Injectables.Lazy<HomeBridgeConnection> HomeBridgeConnection { get; set; }

        public void RegisterBackgroundTasks(Action<Type> registerer)
        {
            var types = typeof(Module).Assembly.GetTypes().Where(t => typeof(IBackgroundTask).IsAssignableFrom(t));
            foreach (var type in types)
            {
                registerer(type);
            }
        }

        public void RegisterEventReactors(Action<Type> registerer)
        {
            var types = typeof(Module).Assembly.GetTypes().Where(t => typeof(IEventReactor).IsAssignableFrom(t));
            foreach (var type in types)
            {
                registerer(type);
            }
        }

        public void RegisterFilterExtensions(Action<Type> registerer)
        {
            var types = typeof(Module).Assembly.GetTypes().Where(t => typeof(IFilterExtension).IsAssignableFrom(t));
            foreach (var type in types)
            {
                registerer(type);
            }
        }

        public void RegisterPluginEvents(Action<Type> registerer)
        {
            var types = typeof(Module).Assembly.GetTypes().Where(t => typeof(EventBase).IsAssignableFrom(t));
            foreach (var type in types)
            {
                registerer(type);
            }
        }

        public void RegisterPluginOptions(Action<IOptions> registerer)
        {
            registerer(new HomeBridgeOptions());
        }
    }
}