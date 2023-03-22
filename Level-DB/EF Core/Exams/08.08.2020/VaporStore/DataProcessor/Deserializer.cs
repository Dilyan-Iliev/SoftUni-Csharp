namespace VaporStore.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.ImportDto;

    public static class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";

        public const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";

        public const string SuccessfullyImportedUser = "Imported {0} with {1} cards";

        public const string SuccessfullyImportedPurchase = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            GameInputJsonDto[] gameDtos = JsonConvert.DeserializeObject<GameInputJsonDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            ICollection<Game> games = new List<Game>();
            ICollection<Developer> developers = new List<Developer>();
            ICollection<Genre> genres = new List<Genre>();
            ICollection<Tag> tags = new List<Tag>();

            foreach (var gameDto in gameDtos)
            {
                if (!IsValid(gameDto)
                    || !gameDto.Tags.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime gameReleaseDate;
                var isParsed = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out gameReleaseDate);

                if (!isParsed)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Game game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = gameReleaseDate,
                };

                Developer developer = FindOrCreate<Developer>(developers,
                    d => d.Name == gameDto.Name,
                    () => new Developer { Name = gameDto.Name });

                Genre genre = FindOrCreate<Genre>(genres,
                    g => g.Name == gameDto.Name,
                    () => new Genre { Name = gameDto.Name });

                game.Developer = developer;
                game.Genre = genre;

                foreach (var tagDto in gameDto.Tags)
                {
                    if (string.IsNullOrEmpty(tagDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Tag tag = FindOrCreate<Tag>(tags,
                        t => t.Name == tagDto,
                        () => new Tag { Name = tagDto });

                    game.GameTags.Add(new GameTag
                    {
                        Tag = tag,
                        Game = game
                    });
                }

                games.Add(game);
                sb.AppendLine(string.Format(SuccessfullyImportedGame, game.Name, game.Genre, game.GameTags.Count));

            }
            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            return "TODO";
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            return "TODO";
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static T FindOrCreate<T>
            (ICollection<T> collection, Func<T, bool> predicate, Func<T> create)
        {
            T obj = collection.FirstOrDefault(predicate)!;

            if (obj == null)
            {
                obj = create();
                collection.Add(obj);
            }

            return obj;
        }
    }
}