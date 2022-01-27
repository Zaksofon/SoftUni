
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.DataProcessor.ImportDto
{
    public class AuthorsImportDto
    {
        public AuthorsImportDto()
        {
            Books = new HashSet<BookDto>();
        }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^([0-9]{3}-){2}[0-9]{4}$")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<BookDto> Books { get; set; }
    }

    public class BookDto
    {
        public int? Id { get; set; }
    }
}
