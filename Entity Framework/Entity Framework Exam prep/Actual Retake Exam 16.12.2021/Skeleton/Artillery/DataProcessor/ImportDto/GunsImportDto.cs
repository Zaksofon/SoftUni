
using System.ComponentModel.DataAnnotations;
using Artillery.Data.Models;
using Artillery.Data.Models.Enums;

namespace Artillery.DataProcessor.ImportDto
{
   public class GunsImportDto
    {
        public int ManufacturerId { get; set; }

        [Range(100, 1350000)]
        public int GunWeight { get; set; }

        [Range(typeof(double), "2.00", "35.00")]
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        [Range(1, 100000)]
        public int Range { get; set; }

        [Required]
        public string GunType { get; set; }

        public int ShellId { get; set; }

        public Country[] Countries { get; set; }
    }

   //•	Id – integer, Primary Key
   //•	ManufacturerId – integer, foreign key(required)
   //•	GunWeight– integer in range[100…1_350_000] (required)
   //•	BarrelLength – double in range[2.00….35.00] (required)
   //•	NumberBuild – integer
   //•	Range – integer in range[1….100_000] (required)
   //•	GunType – enumeration of GunType, with possible values(Howitzer, Mortar, FieldGun, AntiAircraftGun, MountainGun, AntiTankGun) (required)
   //•	ShellId – integer, foreign key(required)
   //•	CountriesGuns – a collection of CountryGun

}
