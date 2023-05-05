namespace Contacts.Services.Contacts
{
    using global::Contacts.Core.Data.Entities;
    using global::Contacts.Services.DTOs;

    public interface IContactsService
    {
        Task<ICollection<AllDto>> GetAllAsync();

        Task AddContact(AddContactDto dto);

        Task<Contact> FindByIdAsync(int contactId);

        Task EditAsync(int contactId, EditContactDto dto);

        Task AddToTeam(int contactId, string userId);

        Task RemoveFromTeam(int contactId, string userId);

        Task<ICollection<AllDto>> GetAddedToTeamAsync(string userId);
    }
}
