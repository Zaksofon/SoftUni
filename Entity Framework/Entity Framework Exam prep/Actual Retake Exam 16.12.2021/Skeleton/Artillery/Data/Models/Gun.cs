
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Artillery.Data.Models.Enums;

namespace Artillery.Data.Models
{
    public class Gun
    {
        public Gun()
        {
            CountriesGuns = new HashSet<CountryGun>();
        }

        public int Id { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public int GunWeight { get; set; }

        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        public int Range { get; set; }

        [Required]
        public GunType GunType { get; set; }

        public int ShellId { get; set; }
        public Shell Shell { get; set; }

        public IEnumerable<CountryGun> CountriesGuns { get; set; }
    }
}
