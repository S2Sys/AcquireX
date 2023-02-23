using Newtonsoft.Json;

namespace AcquireX.Core.DTO
{
    public partial class RSHughesProduct
    {
        [JsonProperty("itemCode")]
        public string ItemCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty("mpn")]
        public string Mpn { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("brand", NullValueHandling = NullValueHandling.Ignore)]
        public string Brand { get; set; }

        [JsonProperty("upc", NullValueHandling = NullValueHandling.Ignore)]
        public string Upc { get; set; }
    }
}

