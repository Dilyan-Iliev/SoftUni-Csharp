namespace ProductShop.DTOs.Export.Products
{
    using Newtonsoft.Json;

    [JsonObject]
    public class SoldProductsModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("buyerFirstName")]
        public string BuyerFirstName { get; set; }

        [JsonProperty("buyerLastName")]
        public string BuyerLastname { get; set; }
    }
}
