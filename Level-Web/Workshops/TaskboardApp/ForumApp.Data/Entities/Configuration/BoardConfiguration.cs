namespace TaskboardApp.Data.Entities.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TaskboardApp.Data.Seeding;

    public class BoardConfiguration
        : IEntityTypeConfiguration<Board>
    {
        private readonly BoardSeeder boardSeeder;

        public BoardConfiguration()
        {
            this.boardSeeder = new BoardSeeder();
        }

        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.HasData(this.boardSeeder.GenerateBoards());
        }
    }
}
