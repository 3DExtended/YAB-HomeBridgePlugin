using System;
using System.Collections.Generic;
using System.Text.Json;

using HomeBridgeCommunication.HomeBridgeObjects;
using HomeBridgeCommunication.Responses;

using RestSharp;

namespace HomeBridgeCommunication
{
    public class HomeBridgeConnection
    {
        private readonly string _hostUrl;
        private readonly string _pin;
        private readonly string _port;

        public HomeBridgeConnection(string hostUrl, string port, string pin)
        {
            this._hostUrl = hostUrl;
            this._port = port;
            this._pin = pin;
        }

        public IReadOnlyList<Accessory> GetAllAccessories()
        {
            var response = this.GetRequest("accessories");
            var castedResponse = JsonSerializer.Deserialize<GetAllAccessoriesRequestResponse>(response.Content);

            return castedResponse.Accessories;
        }

        private IRestResponse GetRequest(string urlPart)
        {
            var client = new RestClient($"http://{_hostUrl}:{_port}/{urlPart}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "Application/json");
            request.AddHeader("authorization", "031-45-154");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return response;
        }
    }
}