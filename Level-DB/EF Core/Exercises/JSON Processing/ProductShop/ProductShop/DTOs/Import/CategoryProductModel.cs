namespace ProductShop.DTOs.Import
{
    using Newtonsoft.Json;

    [JsonObject]
    public class CategoryProductModel
    {
        public int CategoryId{ get; set; }

        public int ProductId{ get; set; }
    }
}
