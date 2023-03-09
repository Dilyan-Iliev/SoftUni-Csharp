namespace ProductShop.DTOs.Export.Products
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ProductsInRangeModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("seller")]
        public string Seller { get; set; }
    }
}
