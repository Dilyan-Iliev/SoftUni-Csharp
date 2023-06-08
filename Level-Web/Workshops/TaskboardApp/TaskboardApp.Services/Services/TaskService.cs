namespace TaskboardApp.Services.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using TaskboardApp.Data;
    using TaskboardApp.Data.Entities;
    using TaskboardApp.Services.Contracts;
    using TaskboardApp.ViewModels.Task;

    public class TaskService
        : ITaskService
    {
        private readonly ApplicationDbContext context;

        public TaskService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(AddTaskViewModel model, string ownerId)
        {
            var task = new TaskEntity()
            {
                Title = model.Title,
                Description = model.Description,
                BoardId = model.BoardId,
                OwnerId = ownerId
            };

            await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var taskForDelete = await FindByIdAsync(id);

            try
            {
               this.context
                    .Tasks
                    .Remove(taskForDelete);

                await this.context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task EditAsync(EditTaskViewModel model, int id)
        {
            var task = await FindByIdAsync(id);

            if (task != null)
            {
                task.Title = model.Title;
                task.Description = model.Description;
                task.BoardId = model.BoardId;

                await this.context.SaveChangesAsync();
            }
        }

        public async Task<TaskEntity?> FindByIdAsync(int id)
        {
            return await this.context
                .Tasks
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<DetailsTaskViewModel?> GetDetailsAsync(int id)
        {
            return await this.context
                .Tasks
                .Where(t => t.Id == id)
                .Select(t => new DetailsTaskViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Owner = t.Owner.Id,
                    Board = t.Board.Name ?? null,
                    CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                })
                .FirstOrDefaultAsync();
        }
    }
}
