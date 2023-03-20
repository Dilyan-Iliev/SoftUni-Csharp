namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context
                .Theatres
                .Where(t => t.NumberOfHalls >= numbersOfHalls
                    && t.Tickets.Count >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                        .Where(tc => tc.RowNumber >= 1 && tc.RowNumber <= 5)
                        .Sum(tc => tc.Price),
                    Tickets = t.Tickets
                        .Where(tc => tc.RowNumber >= 1 && tc.RowNumber <= 5)
                        .Select(tc => new
                        {
                            Price = tc.Price,
                            RowNumber = tc.RowNumber,
                        })
                        .OrderByDescending(tc => tc.Price)
                        .ToArray()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            return JsonConvert.SerializeObject(theatres, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double raiting)
        {
            XmlRootAttribute root = new XmlRootAttribute("Plays");
            XmlSerializer serializer = new XmlSerializer(typeof(PlayOutputXmlDto[]), root);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var plays = context
                .Plays
                .ToArray()
                .Where(p => p.Rating <= raiting)
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .Select(p => new PlayOutputXmlDto
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                        .Where(c => c.IsMainCharacter)
                        .Select(c => new ActorOutputXmlDto
                        {
                            FullName = c.FullName,
                            MainCharacter = $"Plays main character in '{p.Title}'."
                        })
                        .OrderByDescending(c => c.FullName)
                        .ToArray()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            using StringWriter sw = new StringWriter(sb);
            serializer.Serialize(sw, plays, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
