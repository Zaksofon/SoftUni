
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artillery.Data.Models
{
    public class Shell
    {
        public Shell()
        {
            Guns = new HashSet<Gun>();
        }

        public int Id { get; set; }

        public double ShellWeight { get; set; }

        [Required]
        public string Caliber { get; set; }

        public IEnumerable<Gun> Guns { get; set; }
    }
}
