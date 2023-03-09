namespace ProductShop.DTOs.Import
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ProductModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int SellerId { get; set; }

        public int? BuyerId { get; set; }
    }
}
