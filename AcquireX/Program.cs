// See https://aka.ms/new-console-template for more information
using AcquireX.Core.Contracts;
using AcquireX.Core.Enum;
using AcquireX.Core.Services;
using AcquireX.Core.Utility;


string clientId = "candidate1";
string clientSecret = "X01BvqCjkbFpsw5d1gAChjg1RrQc3c2q";
string tokenEndpoint = "https://auth.dkhardware.com/realms/ctesting/protocol/openid-connect/token";
string rsHughesServiceUrl = "https://dkh-c-testing-api.staging.dkhdev.com/products/json";
string bannerServiceUrl = "https://dkh-c-testing-api.staging.dkhdev.com/products/xml";

var oauthService = OAuthService.GetInstance(clientId, clientSecret, tokenEndpoint);
var dataSourceFactory = new DataSourceFactory(oauthService);

var bannerDataSource = dataSourceFactory.CreateDataSource(DataSourceType.Banner, bannerServiceUrl);
var bannerProducts = await bannerDataSource.GetProductsAsync();

var rsHughesDataSource = dataSourceFactory.CreateDataSource(DataSourceType.RSHughes, rsHughesServiceUrl);
var rsHughesProducts = await rsHughesDataSource.GetProductsAsync();
 

UPCProductMatcher matcher = new UPCProductMatcher();

if (rsHughesProducts.Any() && bannerProducts.Any())
{
    var matchedProd = matcher.Match(rsHughesProducts, bannerProducts);
    if (matchedProd.Any())
        foreach (var product in matchedProd)
        {

            Console.WriteLine($"{product.Upc} {product.ItemCode}");
        }
}
Console.ReadLine();
