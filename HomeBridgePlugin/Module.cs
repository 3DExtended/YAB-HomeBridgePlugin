using System;
using System.Linq;

using YAB.Core.EventReactor;
using YAB.Core.Events;
using YAB.Plugins;
using YAB.Plugins.Injectables.Options;

namespace HomeBridgePlugin
{
    public class Module : IPluginModule
    {
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
        }
    }
}