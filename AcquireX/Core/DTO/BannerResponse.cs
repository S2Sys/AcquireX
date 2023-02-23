using System.Xml.Serialization;

namespace AcquireX.Core.DTO
{
    [XmlRoot(ElementName = "ProductsResponse")]
    public class BannerResponse
    {

        [XmlElement(ElementName = "product")]
        public List<BannerProduct> Products { get; set; }

    }
}

