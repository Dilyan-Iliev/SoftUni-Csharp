namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";



        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Plays");
            XmlSerializer serializer = new XmlSerializer(typeof(PlayInputXmlDto[]), root);

            using StringReader sr = new StringReader(xmlString);
            PlayInputXmlDto[] playDtos = (PlayInputXmlDto[])serializer.Deserialize(sr);

            StringBuilder sb = new StringBuilder();

            string[] validGenres = { "Drama", "Comedy", "Romance", "Musical" };
            TimeSpan minTime = new TimeSpan(1, 0, 0);
            ICollection<Play> plays = new List<Play>();

            foreach (var playDto in playDtos)
            {
                TimeSpan dtoDuration = TimeSpan.ParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture);

                if (!IsValid(playDto)
                    || !validGenres.Contains(playDto.Genre)
                    || dtoDuration < minTime)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                Play play = new Play
                {
                    Title = playDto.Title,
                    Duration = dtoDuration,
                    Rating = playDto.Rating,
                    Genre = (Genre)Enum.Parse(typeof(Genre), playDto.Genre),
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };

                plays.Add(play);
                sb.AppendLine(string.Format(SuccessfulImportPlay, play.Title, play.Genre.ToString(), play.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Casts");
            XmlSerializer serializer = new XmlSerializer(typeof(CastInputXmlDto[]), root);

            using StringReader sr = new StringReader(xmlString);
            CastInputXmlDto[] castDtos = (CastInputXmlDto[])serializer.Deserialize(sr);

            StringBuilder sb = new StringBuilder();
            ICollection<Cast> casts = new List<Cast>();

            foreach (var castDto in castDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };

                casts.Add(cast);
                string characterType = cast.IsMainCharacter ? "main" : "lesser";
                sb.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, characterType));
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            TheatreInputJsonDto[] theatreDtos = JsonConvert.DeserializeObject<TheatreInputJsonDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            IList<Theatre> theatres = new List<Theatre>();

            foreach (var theatreDto in theatreDtos)
            {
                if (!IsValid(theatreDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre theatre = new Theatre
                {
                    Name = theatreDto.Name,
                    NumberOfHalls = theatreDto.NumberOfHalls,
                    Director = theatreDto.Director,
                };

                foreach (var ticketDto in theatreDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket ticket = new Ticket
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId
                    };

                    theatre.Tickets.Add(ticket);
                }

                theatres.Add(theatre);
                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.Theatres.AddRange(theatres);
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
