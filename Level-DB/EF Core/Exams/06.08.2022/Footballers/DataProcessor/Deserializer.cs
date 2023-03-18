namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Coaches");
            XmlSerializer serializer = new XmlSerializer(typeof(CoachInputXmlModel[]), root);

            using StringReader sr = new StringReader(xmlString);

            var coachModels = (CoachInputXmlModel[])serializer.Deserialize(sr);

            StringBuilder sb = new StringBuilder();
            IList<Coach> coaches = new List<Coach>();

            foreach (var coachModel in coachModels)
            {
                if (!IsValid(coachModel))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Coach coach = new Coach
                {
                    Name = coachModel.Name,
                    Nationality = coachModel.Nationality,
                };

                foreach (var footballerModel in coachModel.Footballers)
                {
                    if (!IsValid(footballerModel))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isContractStartDateParsed = DateTime.TryParseExact(footballerModel.ContractStartDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out var contractStartDate);

                    if (!isContractStartDateParsed)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isContractEndDateParsed = DateTime.TryParseExact(footballerModel.ContractEndDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out var contractEndDate);

                    if (!isContractEndDateParsed)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (contractStartDate >= contractEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer footballer = new Footballer
                    {
                        Name = footballerModel.Name,
                        ContractStartDate = contractStartDate,
                        ContractEndDate = contractEndDate,
                        BestSkillType = (BestSkillType)footballerModel.BestSkillType,
                        PositionType = (PositionType)footballerModel.PositionType
                    };

                    coach.Footballers.Add(footballer);

                }
                coaches.Add(coach);
                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
            }

            context.Coaches.AddRange(coaches);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            TeamInputJsonModel[] teamModels = JsonConvert.DeserializeObject<TeamInputJsonModel[]>(jsonString);

            int[] validFootballerIds = context
                .Footballers
                .AsNoTracking()
                .Select(f => f.Id)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            ICollection<Team> teams = new List<Team>();

            foreach (var teamModel in teamModels)
            {
                if (!IsValid(teamModel))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (teamModel.Trophies == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team team = new Team
                {
                    Name = teamModel.Name,
                    Nationality = teamModel.Nationality,
                    Trophies = teamModel.Trophies,
                };

                foreach (var footballerId in teamModel.FootballersIds.Distinct())
                {
                    if (!validFootballerIds.Contains(footballerId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    team.TeamsFootballers.Add(new TeamFootballer
                    {
                        Team = team,
                        FootballerId = footballerId
                    });
                }

                teams.Add(team);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }

            context.Teams.AddRange(teams);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
