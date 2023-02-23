// See https://aka.ms/new-console-template for more information
using AcquireX.Core.Contracts;
using AcquireX.Core.Enum;
using AcquireX.Core.Model;
using AcquireX.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args).Build();

IConfiguration config = host.Services.GetRequiredService<IConfiguration>();

 

string clientId = config["OAuth:ClientId"]; 
string clientSecret = config["OAuth:Secret"]; 
string tokenEndpoint = config["OAuth:Endpoint"]; 
string rsHughesServiceUrl = config["ServicesEndpoints:Hughes"]; 
string bannerServiceUrl = config["ServicesEndpoints:Banner"]; 

var oauthService = OAuthService.GetInstance(clientId, clientSecret, tokenEndpoint);
var dataSourceFactory = new DataSourceFactory(oauthService);

var dataSource = dataSourceFactory.CreateDataSource(DataSourceType.Banner, bannerServiceUrl);
var bannerProducts = await dataSource.GetProductsAsync();

dataSource = dataSourceFactory.CreateDataSource(DataSourceType.RSHughes, rsHughesServiceUrl);
var rsHughesProducts = await dataSource.GetProductsAsync();
ProductMatcherService matcher = new ProductMatcherService();

var products = matcher.Fetch(rsHughesProducts, bannerProducts);
if (products.Any())
    foreach (var product in products)
    {

        Console.WriteLine($"{product.Upc} {product.ItemCode}");
    }
else
{
    Console.WriteLine($"No product found");
}
Console.ReadLine();
