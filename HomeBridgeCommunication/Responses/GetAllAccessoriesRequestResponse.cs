using System.Collections.Generic;
using System.Text.Json.Serialization;

using HomeBridgeCommunication.HomeBridgeObjects;

namespace HomeBridgeCommunication.Responses
{
    public class GetAllAccessoriesRequestResponse
    {
        [JsonPropertyName("accessories")]
        public List<Accessory> Accessories { get; } = new List<Accessory>();
    }
}