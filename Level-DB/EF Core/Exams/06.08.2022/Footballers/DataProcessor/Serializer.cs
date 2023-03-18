namespace Footballers.DataProcessor
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FootballersProfile>();
            });
            var mapper = new Mapper(config);

            XmlRootAttribute root = new XmlRootAttribute("Coaches");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            XmlSerializer serializer = new XmlSerializer(typeof(CoachOutputXmlModel[]), root);

            StringBuilder sb = new StringBuilder();
            using StringWriter sw = new StringWriter(sb);

            var coachesWithFootballers = context
                .Coaches
                .Where(c => c.Footballers.Any())
                .ProjectTo<CoachOutputXmlModel>(config)
                .OrderByDescending(c => c.FootballersCount)
                .ThenBy(c => c.Name)
                .ToArray();

            serializer.Serialize(sw, coachesWithFootballers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teamsWithMostFootballers = context
                .Teams
                .ToArray()
                .Where(t => t.TeamsFootballers.Any(tf => tf.Footballer.ContractStartDate >= date))
                .Select(t => new TeamOutputJsonModel
                {
                    TeamName = t.Name,
                    Footballers = t.TeamsFootballers
                        .Where(tf => tf.Footballer.ContractStartDate >= date)
                        .OrderByDescending(tf => tf.Footballer.ContractStartDate)
                        .ThenBy(tf => tf.Footballer.Name)
                        .Select(tf => new TeamFootballersOutputJsonModel
                        {
                            Name = tf.Footballer.Name,
                            ContractStartDate = tf.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                            ContractEndDate = tf.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                            BestSkillType = tf.Footballer.BestSkillType.ToString(),
                            PositionType = tf.Footballer.PositionType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(t => t.Footballers.Length)
                .ThenBy(t => t.TeamName)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(teamsWithMostFootballers, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
