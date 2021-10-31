using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using HomeBridgeCommunication.HomeBridgeObjects;

using HomeBridgePlugin.Events;
using HomeBridgePlugin.Options;

using Microsoft.Extensions.Logging;

using YAB.Core.Events;
using YAB.Plugins;
using YAB.Plugins.Injectables;

namespace HomeBridgePlugin.BackgroundTasks
{
    public class HomeBridgeObserver : IBackgroundTask
    {
        private readonly IEventSender _eventSender;
        private readonly ILogger _logger;
        private readonly HomeBridgeOptions _options;
        private readonly IPipelineStore _pipelineStore;
        private List<AccessoryDetails> _homeBridgeAccessories;

        public HomeBridgeObserver(IPipelineStore pipelineStore, ILogger logger, HomeBridgeOptions options, IEventSender eventSender)
        {
            _options = options;
            _eventSender = eventSender;
            _logger = logger;
            _pipelineStore = pipelineStore;
        }

        public Task InitializeAsync(CancellationToken cancellation)
        {
            Module.HomeBridgeConnection = new YAB.Plugins.Injectables.Lazy<HomeBridgeCommunication.HomeBridgeConnection>(()
                => new HomeBridgeCommunication.HomeBridgeConnection(
                    _options.HomeBridgeHostUrl,
                    _options.HomeBridgeHostPort,
                    _options.HomeBridgeUserName,
                    _options.HomeBridgePassword));
            return Task.CompletedTask;
        }

        public async Task RunUntilCancelledAsync(CancellationToken cancellationToken)
        {
            var homeBridgeConnection = Module.HomeBridgeConnection.Value;

            _homeBridgeAccessories = await homeBridgeConnection.GetAllAccessoriesAsync(cancellationToken).ConfigureAwait(false);

            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(_options.HomeBridgeChangeDetectorFrequencyInSeconds * 1000, cancellationToken).ConfigureAwait(false);
                var newestVersionOfAccessories = await homeBridgeConnection
                    .GetAllAccessoriesAsync(cancellationToken)
                    .ConfigureAwait(false);

                var eventsToSend = new List<EventBase>();

                // check if some value changed:
                // and only check accessories that are both in lists
                foreach (var newAccessoryState in newestVersionOfAccessories)
                {
                    var oldAccessoryState = _homeBridgeAccessories.SingleOrDefault(a => a.UniqueId == newAccessoryState.UniqueId);
                    if (oldAccessoryState is null)
                    {
                        continue;
                    }

                    foreach (var newCharacteristicState in newAccessoryState.ServiceCharacteristics)
                    {
                        var oldCharacteriticState = oldAccessoryState.ServiceCharacteristics
                            .SingleOrDefault(c => c.Type == newCharacteristicState.Type
                                && c.ServiceName == newCharacteristicState.ServiceName);
                        if (oldCharacteriticState is null)
                        {
                            continue;
                        }

                        if (oldCharacteriticState.Value != newCharacteristicState.Value)
                        {
                            eventsToSend.Add(new HomeBridgeAccessoryValueChangedEvent
                            {
                                Id = Guid.NewGuid(),
                                AccessoryName = newAccessoryState.ServiceName,
                                AccessoryUniqueId = newAccessoryState.UniqueId,
                                CharacteristicType = newCharacteristicState.Type,
                                NewValue = newCharacteristicState.Value.ToString()
                            });
                        }
                    }
                }

                // send all events
                await Task.WhenAll(eventsToSend.Select(evt => _eventSender.SendEvent(evt, cancellationToken))).ConfigureAwait(false);

                _homeBridgeAccessories = newestVersionOfAccessories;
            }
        }
    }
}