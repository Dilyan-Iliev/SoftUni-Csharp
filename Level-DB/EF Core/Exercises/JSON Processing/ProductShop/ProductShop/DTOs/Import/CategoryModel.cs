namespace ProductShop.DTOs.Import
{
    using Newtonsoft.Json;

    [JsonObject]
    public class CategoryModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
