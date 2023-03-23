namespace VaporStore.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using VaporStore.Constants;

    [JsonObject]
    public class UserInputJsonDto
    {
        [JsonProperty("FullName")]
        [Required]
        [RegularExpression(UserConstants.UserFullNameRegex)]
        public string FullName { get; set; }

        [JsonProperty("Username")]
        [Required]
        [StringLength(UserConstants.UsernameMaxLength, MinimumLength = UserConstants.UsernameMinLength)]
        public string Username { get; set; }

        [JsonProperty("Email")]
        [Required]
        public string Email { get; set; }

        [JsonProperty("Age")]
        [Range(UserConstants.UserMinAge, UserConstants.UserMaxAge)]
        public int Age { get; set; }

        [JsonProperty("Cards")]
        public CardInputJsonDto[] Cards { get; set; }
    }
}
