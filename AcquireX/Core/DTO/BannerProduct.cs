using System.Xml.Serialization;

namespace AcquireX.Core.DTO
{
    [XmlRoot(ElementName = "product")]
    public class BannerProduct
    {

        [XmlElement(ElementName = "itemCode")]
        public string ItemCode { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "manufacturer")]
        public string Manufacturer { get; set; }

        [XmlElement(ElementName = "upc")]
        public string Upc { get; set; }

        [XmlElement(ElementName = "price")]
        public double Price { get; set; }

        [XmlElement(ElementName = "brand")]
        public string Brand { get; set; }
    }
}

