using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Artillery.Data.Models;
using Artillery.Data.Models.Enums;
using Artillery.DataProcessor.ImportDto;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;

namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Artillery.Data;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(
                typeof(CountriesImportDto[]),
                new XmlRootAttribute("Countries"));
            var countryXmlAsString =
                (CountriesImportDto[])xmlSerializer.Deserialize(
                    new StringReader(xmlString));

            var sb = new StringBuilder();

            foreach (var countryXml in countryXmlAsString)
            {
                if (!IsValid(countryXml))
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }

                var country = new Country()
                {
                    CountryName = countryXml.CountryName,
                    ArmySize = countryXml.ArmySize
                };
                context.Countries.Add(country);
                context.SaveChanges();
                sb.AppendLine($"Successfully import {countryXml.CountryName} with {countryXml.ArmySize} army personnel.");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(
                typeof(ManufacturerImportDto[]),
                new XmlRootAttribute("Manufacturers"));
            var manufacturerXmlAsString =
                (ManufacturerImportDto[])xmlSerializer.Deserialize(
                    new StringReader(xmlString));
            
            var sb = new StringBuilder();

            foreach (var manufacturerXml in manufacturerXmlAsString)
            {
                if (!IsValid(manufacturerXml) || context.Manufacturers.Any(x => x.ManufacturerName == manufacturerXml.ManufacturerName))
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }

                var manufacturer = new Manufacturer()
                {
                    ManufacturerName = manufacturerXml.ManufacturerName,
                    Founded = manufacturerXml.Founded
                };

                var townToken = manufacturerXml.Founded
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string townName = townToken[townToken.Count - 2];

                var countryToken = manufacturerXml.Founded
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string countryName = countryToken[countryToken.Count - 1];

                context.Manufacturers.Add(manufacturer);
                context.SaveChanges();
                sb.AppendLine($"Successfully import manufacturer {manufacturerXml.ManufacturerName} founded in {townName}, {countryName}.");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(
                typeof(ShellsImportDto[]),
                new XmlRootAttribute("Shells"));
            var shellXmlAsString =
                (ShellsImportDto[])xmlSerializer.Deserialize(
                    new StringReader(xmlString));

            var sb = new StringBuilder();

            foreach (var shellXml in shellXmlAsString)
            {
                if (!IsValid(shellXml))
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }

                var shell = new Shell()
                {
                    ShellWeight = shellXml.ShellWeight,
                    Caliber = shellXml.Caliber
                };

                context.Shells.Add(shell);
                context.SaveChanges();
                sb.AppendLine(
                    $"Successfully import shell caliber #{shellXml.Caliber} weight {shellXml.ShellWeight} kg.");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var gunJsonAsString = JsonConvert.DeserializeObject<IEnumerable<GunsImportDto>>(jsonString);

            var sb = new StringBuilder();

            var countries = new List<Country>();
            foreach (var gunJson in gunJsonAsString)
            {
                if (!IsValid(gunJson))
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }

                var gun = new Gun()
                {
                    ManufacturerId = gunJson.ManufacturerId,
                    GunWeight = gunJson.GunWeight,
                    BarrelLength = gunJson.BarrelLength,
                    NumberBuild = gunJson.NumberBuild,
                    Range = gunJson.Range,
                    GunType = Enum.Parse<GunType>(gunJson.GunType),
                    ShellId = gunJson.ShellId,
                };

                foreach (var countryJson in gunJson.Countries)
                {
                    var country = new Country()
                    {
                        Id = countryJson.Id
                    };
                    context.CountryGuns.Add(new CountryGun() { Country = country });

                    countries.Add(country);
                }
           
                context.Guns.Add(gun);
                context.SaveChanges();
                sb.AppendLine(
                    $"Successfully import gun {gunJson.GunType} with a total weight of {gunJson.GunWeight} kg. and barrel length of {gunJson.BarrelLength} m.");
            }

           return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
