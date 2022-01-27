
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class CountriesImportDto
    {
        [Required]
        [XmlElement("CountryName")]
        [StringLength(60, MinimumLength = 4)]
        public string CountryName { get; set; }

        [XmlElement("ArmySize")]
        [Range(50000, 10000000)]
        public int ArmySize { get; set; }
    }
}
