
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class UsersCardsImportDto
    {
        [Required]
        [RegularExpression("[A-Z][a-z]{2,} [A-Z][a-z]{2,}")]
        public string FullName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        public IEnumerable<CardImportDto> Cards { get; set; }


        public class CardImportDto
        {
            [Required]
            [RegularExpression("([0-9]{4} ){3}[0-9]{4}")]
            public string Number { get; set; }

            [Required]
            [RegularExpression("[0-9]{3}")]
            public string CVC { get; set; }

            [Required]
            public CardType? Type { get; set; }
        }

    }
}
