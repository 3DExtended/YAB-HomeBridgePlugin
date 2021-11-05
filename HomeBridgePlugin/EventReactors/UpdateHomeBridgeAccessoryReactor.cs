using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using YAB.Core.EventReactor;
using YAB.Core.Events;

namespace HomeBridgePlugin.EventReactors
{
    public class UpdateHomeBridgeAccessoryReactor : IEventReactor<UpdateHomeBridgeAccessoryReactorConfiguration, EventBase>
    {
        private readonly ILogger _logger;

        public UpdateHomeBridgeAccessoryReactor(ILogger logger)
        {
            _logger = logger;
        }

        public async Task RunAsync(UpdateHomeBridgeAccessoryReactorConfiguration config, EventBase evt, CancellationToken cancellationToken)
        {
            var connection = Module.HomeBridgeConnection.Value;
            // first load all accessories
            var allAccessories = await connection.GetAllAccessoriesAsync(cancellationToken).ConfigureAwait(false);

            // get accessory with name
            var accessory = allAccessories.SingleOrDefault(a => a.ServiceName == config.AccessoryName);

            if (accessory is null)
            {
                _logger.LogError($"Could not find an HomeBridge accessory with name {config.AccessoryName}. Here is a list of all accessible accessories: ");
                _logger.LogError(string.Join("\r\n", allAccessories.Select(a => a.ServiceName)));
                _logger.LogError("Please select one of those accessories to change.");
                return;
            }

            if (!accessory.ServiceCharacteristics.Any(c => c.Type == config.CharacteristicTypeName))
            {
                _logger.LogError($"Could not find an characteristic on accessory with name {config.AccessoryName}. Here is a list of all accessible characteristics: ");
                _logger.LogError(string.Join("\r\n", accessory.ServiceCharacteristics.Select(a => a.Type)));
                _logger.LogError("Please select one of those characteristics to change.");
                return;
            }

            // update characteristic
            await connection.SetCharacteristicOnAccessoryByAccessoryUniqueIdAndCharacteristicTypeAsync(accessory.UniqueId, config.CharacteristicTypeName, config.ValueToSet, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}