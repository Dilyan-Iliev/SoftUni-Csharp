namespace ForumApp.Infrastructure.Data.Entities.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PostConfiguration
        : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(SeedPosts());
            builder
                .Property(p => p.IsDeleted)
                .HasDefaultValue(false);
        }

        private Post[] SeedPosts()
        {
            return new Post[]
            {
                new Post()
                {
                    Id = 1,
                    Title = "My first post",
                    Content = "My first post will be about performin CRUD operations in MVC",
                },

                new Post()
                {
                    Id = 2,
                    Title = "My second post",
                    Content = "My second post will be about performin CRUD operations in MVC 2.0",
                },

                new Post()
                {
                    Id = 3,
                    Title = "My third post",
                    Content = "My third post will be about performin CRUD operations in MVC 3.0",
                }
            };
        }
    }
}
