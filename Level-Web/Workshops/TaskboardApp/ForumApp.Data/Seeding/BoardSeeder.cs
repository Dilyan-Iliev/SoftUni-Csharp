namespace TaskboardApp.Data.Seeding
{
    using TaskboardApp.Data.Entities;

    public class BoardSeeder
    {
        public Board[] GenerateBoards()
        {
            return new Board[]
            {
                new Board
                {
                    Id = 1,
                    Name = "Open",
                },

                new Board
                {
                    Id = 2,
                    Name = "In progress",
                }
            };
        }
    }
}
