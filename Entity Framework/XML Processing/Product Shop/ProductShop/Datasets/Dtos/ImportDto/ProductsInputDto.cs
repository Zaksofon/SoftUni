
using System.Xml.Serialization;

namespace ProductShop.Datasets.Dtos.ImportDto
{
    [XmlType("Product")]
    public class ProductsInputDto
    {
        [XmlElement("name")] public string Name { get; set; }

        [XmlElement("price")] public string Price { get; set; }

        [XmlElement("sellerId")] public int SellerId { get; set; }

        [XmlElement("buyerId")] public int? BuyerId { get; set; }
    }
}
