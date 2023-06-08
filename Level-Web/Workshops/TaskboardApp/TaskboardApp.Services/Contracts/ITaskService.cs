namespace TaskboardApp.Services.Contracts
{
    using System.Threading.Tasks;
    using TaskboardApp.Data.Entities;
    using TaskboardApp.ViewModels.Task;

    public interface ITaskService
    {
        Task AddAsync(AddTaskViewModel model, string ownerId);

        Task<DetailsTaskViewModel?> GetDetailsAsync(int id);

        Task<TaskEntity?> FindByIdAsync(int id);

        Task EditAsync(EditTaskViewModel model, int id);

        Task DeleteAsync(int id);
    }
}
