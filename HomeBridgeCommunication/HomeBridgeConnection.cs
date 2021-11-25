using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using HomeBridgeCommunication.HomeBridgeObjects;
using HomeBridgeCommunication.Responses;

using Newtonsoft.Json;

using RestSharp;

namespace HomeBridgeCommunication
{
    public class HomeBridgeConnection
    {
        private readonly string _hostUrl;
        private readonly string _password;
        private readonly string _port;
        private readonly string _username;
        private LoginRequestResponse _loginStatus = null;

        public HomeBridgeConnection(string hostUrl, string port, string username, string password)
        {
            this._hostUrl = hostUrl;
            this._port = port;
            this._username = username;
            this._password = password;
        }

        public async Task<AccessoryDetails> GetAccessoryByUniqueId(string uniqueIdOfAccessory, CancellationToken cancellationToken)
        {
            var response = await GetRequestAsync("api/accessories/" + uniqueIdOfAccessory, cancellationToken: cancellationToken).ConfigureAwait(false);
            var castedResponse = JsonConvert.DeserializeObject<AccessoryDetails>(response.Content);
            return castedResponse;
        }

        public async Task<List<AccessoryDetails>> GetAllAccessoriesAsync(CancellationToken cancellationToken)
        {
            var response = await GetRequestAsync("api/accessories", cancellationToken: cancellationToken).ConfigureAwait(false);
            var castedResponse = JsonConvert.DeserializeObject<List<AccessoryDetails>>(response.Content);
            return castedResponse;
        }

        public async Task<bool> SetCharacteristicOnAccessoryByAccessoryUniqueIdAndCharacteristicTypeAsync(string accessoryUniqueId, string characteristicType, string newValue, CancellationToken cancellationToken)
        {
            var response = await PutRequestAsync("api/accessories/" + accessoryUniqueId, $"{{\"characteristicType\": \"{characteristicType}\", \"value\": \"{newValue}\"}}", cancellationToken: cancellationToken).ConfigureAwait(false);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        private async Task<IRestResponse> GetRequestAsync(string urlPart, bool ensureLoggedIn = true, CancellationToken cancellationToken = default)
        {
            if (_loginStatus is null && ensureLoggedIn)
            {
                var result = await LoginAsync(cancellationToken);
            }

            IRestResponse response = await MakeRequest().ConfigureAwait(false);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized && ensureLoggedIn)
            {
                await LoginAsync(cancellationToken);

                response = await MakeRequest().ConfigureAwait(false);
            }

            return response;

            async Task<IRestResponse> MakeRequest()
            {
                var client = new RestClient($"http://{_hostUrl}:{_port}/{urlPart}");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                if (_loginStatus is not null)
                {
                    request.AddHeader("Authorization", $"Bearer {_loginStatus.AccessToken}");
                }
                IRestResponse response = await client.ExecuteAsync(request, cancellationToken).ConfigureAwait(false);
                return response;
            }
        }

        private async Task<bool> LoginAsync(CancellationToken cancellationToken)
        {
            var response = await PostRequestAsync("api/auth/login", $"{{\"username\":\"{this._username}\", \"password\":\"{this._password}\", \"otp\":\"string\"}}", false, cancellationToken).ConfigureAwait(false);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                // successfully logged in:
                this._loginStatus = JsonConvert.DeserializeObject<LoginRequestResponse>(response.Content);
                return true;
            }
            return false;
        }

        private async Task<IRestResponse> PostRequestAsync(string urlPart, string bodyJson, bool ensureLoggedIn = true, CancellationToken cancellationToken = default)
        {
            if (_loginStatus is null && ensureLoggedIn)
            {
                var result = await LoginAsync(cancellationToken);
            }

            IRestResponse response = await MakeRequest().ConfigureAwait(false);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized && ensureLoggedIn)
            {
                await LoginAsync(cancellationToken);

                response = await MakeRequest().ConfigureAwait(false);
            }

            return response;

            async Task<IRestResponse> MakeRequest()
            {
                var client = new RestClient($"http://{_hostUrl}:{_port}/{urlPart}");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("accept", "*/*");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", bodyJson, ParameterType.RequestBody);
                if (_loginStatus is not null)
                {
                    request.AddHeader("Authorization", $"Bearer {_loginStatus.AccessToken}");
                }
                IRestResponse response = await client.ExecuteAsync(request, cancellationToken).ConfigureAwait(false);
                return response;
            }
        }

        private async Task<IRestResponse> PutRequestAsync(string urlPart, string bodyJson, bool ensureLoggedIn = true, CancellationToken cancellationToken = default)
        {
            if (_loginStatus is null && ensureLoggedIn)
            {
                var result = await LoginAsync(cancellationToken);
            }

            IRestResponse response = await MakeRequest().ConfigureAwait(false);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized && ensureLoggedIn)
            {
                await LoginAsync(cancellationToken);

                response = await MakeRequest().ConfigureAwait(false);
            }

            return response;

            async Task<IRestResponse> MakeRequest()
            {
                var client = new RestClient($"http://{_hostUrl}:{_port}/{urlPart}");
                client.Timeout = -1;
                var request = new RestRequest(Method.PUT);
                request.AddHeader("accept", "*/*");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", bodyJson, ParameterType.RequestBody);
                if (_loginStatus is not null)
                {
                    request.AddHeader("Authorization", $"Bearer {_loginStatus.AccessToken}");
                }
                IRestResponse response = await client.ExecuteAsync(request, cancellationToken).ConfigureAwait(false);
                return response;
            }
        }
    }
}