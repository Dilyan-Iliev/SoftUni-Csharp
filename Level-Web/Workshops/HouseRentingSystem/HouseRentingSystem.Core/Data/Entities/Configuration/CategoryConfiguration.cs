namespace HouseRentingSystem.Core.Data.Entities.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryConfiguration
        : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(SeedCategories());
        }

        private List<Category> SeedCategories()
        {
            return new List<Category>()
            {
                new Category
                {
                    Id = 1,
                    Name = "Cottage"
                },
                new Category
                {
                    Id = 2,
                    Name = "Single-Family"
                },
                new Category
                {
                    Id = 3,
                    Name = "Duplex"
                },
            };
        }
    }
}
