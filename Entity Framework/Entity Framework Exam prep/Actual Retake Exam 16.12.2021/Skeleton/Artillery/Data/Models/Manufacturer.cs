
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Artillery.Data.Models;

namespace Artillery.Data
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            Guns = new HashSet<Gun>();
        }

        public int Id { get; set; }

        [Required]
        public string ManufacturerName { get; set; }

        [Required]
        public string Founded { get; set; }

        public IEnumerable<Gun> Guns { get; set; }
    }
}
