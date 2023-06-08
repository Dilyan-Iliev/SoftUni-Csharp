namespace TaskboardApp.Data.Seeding
{
    using TaskboardApp.Data.Entities;

    public class TaskSeeder
    {
        public TaskEntity[] GenerateTasks()
        {
            return new TaskEntity[]
            {
                new TaskEntity()
                {
                    Id = 1,
                    Title = "Improve CSS styles",
                    Description = "Implement better styling for all public pages",
                    CreatedOn = DateTime.UtcNow,
                    BoardId = 1,
                    OwnerId = "c349cc97-3108-4452-9cd5-2d6cd184bd11"
                },
            };
        }
    }
}
