// See https://aka.ms/new-console-template for more information
using AcquireX.Core.Contracts;
using AcquireX.Core.Services;
using AcquireX.Core.Utility;
 

string clientId = "candidate1";
string clientSecret = "X01BvqCjkbFpsw5d1gAChjg1RrQc3c2q";
string tokenEndpoint = "https://auth.dkhardware.com/realms/ctesting/protocol/openid-connect/token";
string rsHughesServiceUrl = "https://dkh-c-testing-api.staging.dkhdev.com/products/json";
string bannerServiceUrl = "https://dkh-c-testing-api.staging.dkhdev.com/products/xml";

var oauthService = OAuthService.GetInstance(clientId, clientSecret, tokenEndpoint);
var rsHughesDataSource = new RSHughesDataSource(oauthService, rsHughesServiceUrl);
var products = await rsHughesDataSource.GetProductsAsync();
var bannerDataSource = new BannerDataSource(oauthService, bannerServiceUrl);
var bannerDataSourceProducts = await bannerDataSource.GetProductsAsync();

UPCProductMatcher matcher = new UPCProductMatcher();
var matchedProd = matcher.Match(products, bannerDataSourceProducts);

foreach (var product in matchedProd)
{

    Console.WriteLine($"{product.Upc} {product.ItemCode}");
}
Console.ReadLine();
