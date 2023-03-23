namespace VaporStore.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
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

                if (!game.GameTags.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                games.Add(game);
                sb.AppendLine(string.Format(SuccessfullyImportedGame, game.Name, game.Genre.Name, game.GameTags.Count));

            }
            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            UserInputJsonDto[] userDtos = JsonConvert.DeserializeObject<UserInputJsonDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            string[] validCardTypes = new[] { "Debit", "Credit" };
            ICollection<User> users = new List<User>();

            foreach (var userDto in userDtos)
            {
                if (!IsValid(userDto)
                    || !userDto.Cards.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                User user = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age
                };

                foreach (var cardDto in userDto.Cards)
                {
                    if (!IsValid(cardDto)
                        || !validCardTypes.Contains(cardDto.Type))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    user.Cards.Add(new Card
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = (CardType)Enum.Parse(typeof(CardType), cardDto.Type)
                    });
                }

                users.Add(user);
                sb.AppendLine(string.Format(SuccessfullyImportedUser, user.Username, user.Cards.Count));
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Purchases");
            XmlSerializer serializer = new XmlSerializer(typeof(PurchaseInputXmlDto[]), root);

            using StringReader sr = new StringReader(xmlString);
            PurchaseInputXmlDto[] purchaseDtos = (PurchaseInputXmlDto[])serializer.Deserialize(sr);

            StringBuilder sb = new StringBuilder();
            string[] validPurchaseTypes = new[] { "Retail", "Digital" };
            ICollection<Purchase> purchases = new List<Purchase>();

            foreach (var purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto)
                    || !validPurchaseTypes.Contains(purchaseDto.Type))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Game game = context.Games
                    .FirstOrDefault(g => g.Name == purchaseDto.Title);

                if (game == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Card card = context.Cards
                    .FirstOrDefault(c => c.Number == purchaseDto.Card);

                if (card == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime purchaseDate;
                bool isParsed = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out purchaseDate);

                if (!isParsed)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Purchase purchase = new Purchase
                {
                    Game = game,
                    Type = (PurchaseType)Enum.Parse(typeof(PurchaseType), purchaseDto.Type),
                    ProductKey = purchaseDto.Key,
                    Card = card,
                    Date = purchaseDate,
                };

                purchases.Add(purchase);
                sb.AppendLine(string.Format(SuccessfullyImportedPurchase, purchase.Game.Name, purchase.Card.User.Username));
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        /// <summary>
        /// Search for an object in the collection. If the object does not exist - object is created and finally returns the object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="predicate"></param>
        /// <param name="create"></param>
        /// <returns></returns>
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