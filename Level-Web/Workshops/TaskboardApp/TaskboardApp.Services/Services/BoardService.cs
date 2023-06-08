namespace TaskboardApp.Services.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using TaskboardApp.Data;
    using TaskboardApp.Data.Entities;
    using TaskboardApp.Services.Contracts;
    using TaskboardApp.ViewModels.Board;
    using TaskboardApp.ViewModels.Task;

    public class BoardService
        : IBoardService
    {
        private readonly ApplicationDbContext context;

        public BoardService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<IndexBoardViewModel>> GetAllAsync()
        {
            return await this.context
                .Boards
                .AsNoTracking()
                .Select(b => new IndexBoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks
                        .Select(t => new IndexTaskViewModel()
                        {
                            Id = t.Id,
                            Title = t.Title,
                            Description = t.Description,
                            Owner = t.Owner.UserName
                        }).ToList()
                }).ToListAsync();
        }

        public async Task<ICollection<BoardViewModel>> GetBoardsAsync()
        {
            return await this.context
                .Boards
                .AsNoTracking()
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToListAsync();
        }
    }
}
