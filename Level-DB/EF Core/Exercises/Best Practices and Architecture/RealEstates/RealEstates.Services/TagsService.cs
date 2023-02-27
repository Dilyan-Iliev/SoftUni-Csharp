namespace RealEstates.Services
{
    using RealEstates.Data;
    using RealEstates.Models;

    public class TagsService
        : BaseService, ITagsService
    {
        private readonly AppDbContext context;
        private readonly IPropertiesService propertiesService;

        public TagsService(AppDbContext context, IPropertiesService propertiesService)
        {
            this.context = context;
            this.propertiesService = propertiesService;
        }

        public void Add(string name, int? importance = null)
        {
            var tag = new Tag()
            {
                Name = name,
                Importance = importance
            };

            this.context.Tags.Add(tag);
            this.context.SaveChanges();
        }

        public void BulkTagToProperties()
        {
            var properties = context
                .Properties
                .ToList();

            foreach (var property in properties)
            {
                var averagePriceForDistrict = this.propertiesService
                    .AveagePricePrerSquareMeter(property.DistrictId);
                if (property.Price >= averagePriceForDistrict)
                {
                    var tag = GetTag("скъп-имот");

                    AddPropertyTag(property, tag);
                }
                else if (property.Price < averagePriceForDistrict)
                {
                    var tag = GetTag("евтин-имот");

                    AddPropertyTag(property, tag);
                }

                var currentDate = DateTime.UtcNow.AddYears(-15);
                if (property.BuiltYear.HasValue
                    && property.BuiltYear.Value <= currentDate.Year)
                {
                    var tag = GetTag("стар-имот");

                    AddPropertyTag(property, tag);


                }
                else if (property.BuiltYear.HasValue
                    && property.BuiltYear.Value > currentDate.Year)
                {
                    var tag = GetTag("нов-имот");
                    AddPropertyTag(property, tag);
                }

                var averagePropertySize = this.propertiesService
                    .AveragePropertySize(property.DistrictId);
                if (property.Size >= averagePropertySize)
                {
                    var tag = GetTag("голям-имот");
                    AddPropertyTag(property, tag);
                } 
                else if (property.Size < averagePropertySize)
                {
                    var tag = GetTag("малък-имот");
                    AddPropertyTag(property, tag);
                }

                if (property.Floor.HasValue 
                    && property.Floor.Value == 1)
                {
                    var tag = GetTag("първи-етаж");
                    AddPropertyTag(property, tag);
                }
                else if (property.Floor.HasValue
                    && property.Floor > 6)
                {
                    var tag = GetTag("хубава-гледка");
                    AddPropertyTag(property, tag);
                }
            }

            context.SaveChanges();
        }

        private static void AddPropertyTag(Property? property, Tag tag)
        {
            property.PropertiesTags.Add(new PropertyTag()
            {
                Property = property,
                Tag = tag
            });
        }

        private Tag GetTag(string tagName)
             => context.Tags.FirstOrDefault(t => t.Name == tagName);
    }
}
