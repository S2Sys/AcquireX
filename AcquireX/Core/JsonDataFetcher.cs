using AcquireX.Core.Contracts;
using Newtonsoft.Json;

namespace AcquireX.Core
{
    public class JsonDataFetcher : IDataFetcher
    {
        private readonly string _url;
        private readonly string _accessToken;

        public JsonDataFetcher(string url, string accessToken)
        {
            _url = url;
            _accessToken = accessToken;
        }

        public async Task<List<Product>> FetchData()
        {
            // Make HTTP request to the data source to get JSON data
            // using the access token
            // ...

            // Convert JSON data into C# objects using deserialization
            var products = JsonConvert.DeserializeObject<List<Product>>(jsonData);

            return products;
        }
    }

}
