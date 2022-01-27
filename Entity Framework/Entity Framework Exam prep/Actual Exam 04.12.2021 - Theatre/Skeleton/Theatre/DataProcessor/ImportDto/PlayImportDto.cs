
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class PlayImportDto
    {
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Title { get; set; }

        [Required]
        [Range(typeof(TimeSpan), "01:00:00", "23:59:59")]
        public string Duration { get; set; }

        [Range(typeof(float), "0.00", "10.00")]
        public float Rating { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [StringLength(700, MinimumLength = 0)]
        public string Description { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Screenwriter { get; set; }
    }
}
