
using System.ComponentModel.DataAnnotations;

namespace Theatre.Data.Models
{
    public class Cast
    {
        public int Id { get; set; }

       [Required]
       [StringLength(30, MinimumLength = 4)]
        public string FullName { get; set; }
        
        [Required]
        public bool IsMainCharacter  { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public int PlayId { get; set; }

        public Play Play { get; set; }
    }
}
