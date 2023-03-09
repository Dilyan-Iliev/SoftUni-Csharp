namespace ProductShop.DTOs.Import
{
    using Newtonsoft.Json;

    [JsonObject]
    public class UserModel
    {
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }
    }
}
