
using System.Xml.Serialization;

namespace ProductShop.Datasets.Dtos.ImportDto
{
    [XmlType("User")]
    public class UsersInputDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")] 
        public int Age { get; set; }
    }
}
