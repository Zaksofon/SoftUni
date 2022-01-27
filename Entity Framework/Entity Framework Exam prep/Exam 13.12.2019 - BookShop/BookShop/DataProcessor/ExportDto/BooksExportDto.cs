
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using BookShop.Data.Models;

namespace BookShop.DataProcessor.ExportDto
{
    [XmlType("Book")]
    public class BooksExportDto
    {
        [XmlAttribute("Pages")]
        public string Pages { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }
    }
}
