
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class PrisonerMailInputDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression("The [A-Z]{1}[a-z]*")]
        public string Nickname { get; set; }

        [Range(18, 65)]
        public int Age { get; set; }

        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        public decimal? Bail { get; set; }

        public int CellId { get; set; }

        public List<MailInputDto> Mails { get; set; }
    }

    public class MailInputDto
    {
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Sender { get; set; }

        [Required]
        [RegularExpression(@"[A-z0-9\s]* str.")]
        public string Address { get; set; }
    }
}
