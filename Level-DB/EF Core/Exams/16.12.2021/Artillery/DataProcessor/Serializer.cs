
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shellsWithGuns = context
                .Shells
                .Where(sh => sh.ShellWeight > shellWeight)
                .Select(sh => new
                {
                    ShellWeight = sh.ShellWeight,
                    Caliber = sh.Caliber,
                    Guns = sh.Guns
                        .Where(g => (int)g.GunType == 3)
                        .Select(g => new
                        {
                            GunType = g.GunType.ToString(),
                            GunWeight = g.GunWeight,
                            BarrelLength = g.BarrelLength,
                            Range = g.Range > 3000 ? "Long-range" : "Regular range"
                        })
                        .OrderByDescending(g => g.GunWeight)
                        .ToArray()
                })
                .OrderBy(sh => sh.ShellWeight)
                .ToArray();

            return JsonConvert.SerializeObject(shellsWithGuns, Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            XmlRootAttribute root = new XmlRootAttribute("Guns");
            XmlSerializer serializer = new XmlSerializer(typeof(GunOutputXmlDto[]), root);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();
            using StringWriter sw = new StringWriter(sb);

            var gunsAndCountries = context
                .Guns
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .Select(g => new GunOutputXmlDto
                {
                    Manufacturer = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    GunWeight = g.GunWeight,
                    BarrelLength = g.BarrelLength,
                    Range = g.Range,
                    Countries = g.CountriesGuns
                        .Where(cg => cg.Country.ArmySize > 4500000)
                        .Select(c => new CountryOutputXmlDto
                        {
                            Country = c.Country.CountryName,
                            ArmySize = c.Country.ArmySize
                        })
                        .OrderBy(c => c.ArmySize)
                        .ToArray()
                })
                .OrderBy(g => g.BarrelLength)
                .ToArray();

            serializer.Serialize(sw, gunsAndCountries, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
