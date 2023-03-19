namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using AutoMapper;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

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
            XmlRootAttribute root = new XmlRootAttribute("Countries");
            XmlSerializer serializer = new XmlSerializer(typeof(CountryInputXmlDto[]), root);

            using StringReader sr = new StringReader(xmlString);

            CountryInputXmlDto[] countryDtos = (CountryInputXmlDto[])serializer.Deserialize(sr);
            StringBuilder sb = new StringBuilder();
            ICollection<Country> countries = new List<Country>();

            foreach (var countryDto in countryDtos)
            {
                if (!IsValid(countryDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Country country = new Country
                {
                    CountryName = countryDto.CountryName,
                    ArmySize = countryDto.ArmySize
                };

                countries.Add(country);

                sb.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.Countries.AddRange(countries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Manufacturers");
            XmlSerializer serializer = new XmlSerializer(typeof(ManufacturerInputXmlDto[]), root);

            using StringReader sr = new StringReader(xmlString);

            ManufacturerInputXmlDto[] manufacturerDtos =
                (ManufacturerInputXmlDto[])serializer.Deserialize(sr);

            StringBuilder sb = new StringBuilder();
            ICollection<Manufacturer> manufacturers = new List<Manufacturer>();

            foreach (var manufacturerDto in manufacturerDtos)
            {
                Manufacturer m = manufacturers
                    .FirstOrDefault(x => x.ManufacturerName == manufacturerDto.ManufacturerName);

                if (!IsValid(manufacturerDto) || m != null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var manufacturer = new Manufacturer
                {
                    ManufacturerName = manufacturerDto.ManufacturerName,
                    Founded = manufacturerDto.Founded
                };

                manufacturers.Add(manufacturer);
                var manufacturerCountry = manufacturer.Founded.Split(", ").ToArray();
                var last = manufacturerCountry.Skip(Math.Max(0, manufacturerCountry.Count() - 2)).ToArray();
                sb.AppendLine(string.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, string.Join(", ", last)));
            }

            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Shells");
            XmlSerializer serializer = new XmlSerializer(typeof(ShellInputXmlDto[]), root);

            using StringReader sr = new StringReader(xmlString);

            ShellInputXmlDto[] shellDtos = (ShellInputXmlDto[])serializer.Deserialize(sr);

            StringBuilder sb = new StringBuilder();

            ICollection<Shell> shells = new List<Shell>();

            foreach (var shellDto in shellDtos)
            {
                if (!IsValid(shellDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Shell shell = new Shell
                {
                    ShellWeight = shellDto.ShellWeight,
                    Caliber = shellDto.Caliber
                };

                shells.Add(shell);

                sb.AppendLine(string.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }

            context.Shells.AddRange(shells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            GunInputJsonDto[] gunDtos = JsonConvert.DeserializeObject<GunInputJsonDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            ICollection<Gun> guns = new List<Gun>();
            string[] validGunTypes = new string[] { "Howitzer", "Mortar", "FieldGun", "AntiAircraf", "MountainGun", "AntiTankGun" };

            foreach (var gunDto in gunDtos)
            {
                if (!IsValid(gunDto)
                    || !validGunTypes.Contains(gunDto.GunType))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var gun = new Gun
                {
                    ManufacturerId = gunDto.ManufacturerId,
                    GunWeight = gunDto.GunWeight,
                    BarrelLength = gunDto.BarrelLength,
                    NumberBuild = gunDto.NumberBuild,
                    Range = gunDto.Range,
                    GunType = (GunType)Enum.Parse(typeof(GunType), gunDto.GunType),
                    ShellId = gunDto.ShellId
                };


                foreach (var country in gunDto.Countries)
                {
                    gun.CountriesGuns.Add(new CountryGun
                    {
                        CountryId = country.Id,
                        Gun = gun
                    });
                }

                guns.Add(gun);
                sb.AppendLine(string.Format(SuccessfulImportGun, gun.GunType, gun.GunWeight, gun.BarrelLength));
            }

            context.Guns.AddRange(guns);
            context.SaveChanges();

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