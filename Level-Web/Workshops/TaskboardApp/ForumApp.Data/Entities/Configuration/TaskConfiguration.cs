namespace TaskboardApp.Data.Entities.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TaskboardApp.Data.Seeding;

    public class TaskConfiguration
        : IEntityTypeConfiguration<TaskEntity>
    {
        private readonly TaskSeeder taskSeeder;

        public TaskConfiguration()
        {
            this.taskSeeder = new TaskSeeder();
        }

        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.taskSeeder.GenerateTasks());
        }
    }
}
