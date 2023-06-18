namespace Homies.Services.Contracts
{
    using Homies.Core.Entities;
    using Homies.ViewModels;

    public interface IEventService
    {
        Task AddAsync(AddEventViewModel model, string organiserId);

        Task<ICollection<TypeViewModel>> GetEventTypesAsync();

        Task<IEnumerable<AllEventsViewModel>> GetAllForCreatorAsync();

        Task<Event?> FindByIdAsync(int id);

        Task EditAsync(int id, EditEventViewModel model);

        Task<ICollection<JoinedEventsViewModel>> GetAllJoinedEventsAsync(string userId);

        Task<EventDetailsViewModel> GetDetailsAsync(int id);

        Task<int> JoinAsync(int id, string userId);

        Task LeaveAsync(int id, string userId);
    }
}
