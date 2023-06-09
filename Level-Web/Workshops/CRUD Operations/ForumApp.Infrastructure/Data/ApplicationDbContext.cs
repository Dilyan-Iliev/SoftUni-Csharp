namespace ForumApp.Infrastructure.Data
{
    using ForumApp.Infrastructure.Data.Entities;
    using ForumApp.Infrastructure.Data.Entities.Configuration;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PageVisit> PageVisits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
