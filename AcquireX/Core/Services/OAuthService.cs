using Newtonsoft.Json.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace AcquireX.Core.Services
{
    public class OAuthService
    {
        private static OAuthService _instance;
        private readonly HttpClient _httpClient;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _tokenEndpoint;
        private string _accessToken;

        private OAuthService(string clientId, string clientSecret, string tokenEndpoint)
        {
            _httpClient = new HttpClient();
            _clientId = clientId;
            _clientSecret = clientSecret;
            _tokenEndpoint = tokenEndpoint;
        }


        public static OAuthService GetInstance(string clientId, string clientSecret, string tokenEndpoint)
        {
            if (_instance == null)
            {
                _instance = new OAuthService(clientId, clientSecret, tokenEndpoint);
            }

            return _instance;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            if (_accessToken == null)
            {
                var tokenRequest = new HttpRequestMessage(HttpMethod.Post, _tokenEndpoint);
                var tokenRequestBody = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "client_id", _clientId },
                { "client_secret", _clientSecret },
                { "scope", "products" }

            };
                tokenRequest.Content = new FormUrlEncodedContent(tokenRequestBody);

                var tokenResponse = await _httpClient.SendAsync(tokenRequest);
                var tokenResponseContent = await tokenResponse.Content.ReadAsStringAsync();
                var tokenResponseJson = JObject.Parse(tokenResponseContent);

                _accessToken = (string)tokenResponseJson["access_token"];
            }

            return _accessToken;
        }
    }

}
