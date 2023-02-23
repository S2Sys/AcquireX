using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcquireX.Core.Contracts;

namespace AcquireX.Core
{

    public class OAuthClient : IOAuthClient
    {
        private readonly string _clientId;
        private readonly string _clientSecret;

        public OAuthClient(string clientId, string clientSecret)
        {   
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        public async Task<string> GetAccessToken()
        {
            // Make HTTP request to the OAuth server to get access token
            // using client ID and client secret
            // ...

            return accessToken;
        }
    }

}
