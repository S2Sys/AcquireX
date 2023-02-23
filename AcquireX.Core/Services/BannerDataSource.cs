using AcquireX.Core.Contracts;
using AcquireX.Core.DTO;
using AcquireX.Core.Model;
using AcquireX.Core.Utility;
using System.Net.Http.Headers;
using System.Xml.Serialization;

namespace AcquireX.Core.Services
{
    public class BannerDataSource : IDataSource
    {
        private readonly OAuthService _oauthService;
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public BannerDataSource(OAuthService oauthService, string baseUrl)
        {
            _oauthService = oauthService;
            _httpClient = new HttpClient();
            _baseUrl = baseUrl;
        }

        public async Task<IList<Product>> GetProductsAsync()
        {
            var accessToken = await _oauthService.GetAccessTokenAsync();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _httpClient.GetAsync(_baseUrl);
            var content = await response.Content.ReadAsStringAsync();
            var serializer = new XmlSerializer(typeof(BannerResponse));
            var result = (BannerResponse)serializer.Deserialize(new StringReader(content));

            return result.Products.ToDTO();
        }
    }

}
