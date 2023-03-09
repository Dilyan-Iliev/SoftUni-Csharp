namespace ProductShop.DTOs.Export.Users
{
    using Newtonsoft.Json;
    using ProductShop.DTOs.Export.Products;

    [JsonObject]
    public class UserWithSoldProductsModel
    {
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("soldProducts")]
        public SoldProductsModel[] SoldProducts { get; set; }
    }
}
