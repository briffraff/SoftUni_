using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Product")]
    public class ProductDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal  Price { get; set; }

        [XmlIgnore]
        [XmlElement("buyer")]
        public string Buyer { get; set; }
    }
}
