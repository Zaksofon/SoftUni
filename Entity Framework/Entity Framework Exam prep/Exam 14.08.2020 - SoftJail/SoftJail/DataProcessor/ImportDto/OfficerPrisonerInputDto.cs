
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using SoftJail.Data.Models.Enums;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class OfficerPrisonerInputDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        [XmlElement("Name")] 
        public string Name { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        [XmlElement("Money")] 
        public decimal Money { get; set; }

        [EnumDataType(typeof(Position))]
        [XmlElement("Position")] 
        public string Position { get; set; }

        [EnumDataType(typeof(Weapon))]
        [XmlElement("Weapon")] 
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")] 
        public int DepartmentID { get; set; }

        [XmlArray("Prisoners")] 
        public PrisonersInputDto[] Prisoners { get; set; }
    }

    [XmlType("Prisoner")]
    public class PrisonersInputDto
    {
        [XmlAttribute("id")] 
        public int Id { get; set; }
    }
}
