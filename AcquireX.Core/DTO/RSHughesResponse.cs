using Newtonsoft.Json;

namespace AcquireX.Core.DTO
{
    public partial class RSHughesResponse
    {
        [JsonProperty("products")]
        public List<RSHughesProduct> Products { get; set; }
    }
}

