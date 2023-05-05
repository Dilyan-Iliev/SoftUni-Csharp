namespace Contacts.Services.Services
{
    using global::Contacts.Core.Data;
    using global::Contacts.Core.Data.Entities;
    using global::Contacts.Services.Contacts;
    using global::Contacts.Services.DTOs;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ContactsService : IContactsService
    {
        private readonly ContactsDbContext context;

        public ContactsService(ContactsDbContext context)
        {
            this.context = context;
        }

        public async Task AddContact(AddContactDto dto)
        {
            Contact contact = new Contact()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address ?? null,
                Website = dto.Website
            };

            await context.Contacts.AddAsync(contact);
            await context.SaveChangesAsync();
        }

        public async Task<Contact> FindByIdAsync(int contactId)
        {
            var contact = await context.Contacts
                .FirstOrDefaultAsync(c => c.Id == contactId);

            return contact ?? null;
        }

        public async Task EditAsync(int contactId, EditContactDto dto)
        {
            var postForEdit = await FindByIdAsync(contactId);
            postForEdit.FirstName = dto.FirstName;
            postForEdit.LastName = dto.LastName;
            postForEdit.Email = dto.Email;
            postForEdit.PhoneNumber = dto.PhoneNumber;
            postForEdit.Address = dto.Address;
            postForEdit.Website = dto.Website;

            await context.SaveChangesAsync();
        }

        public async Task<ICollection<AllDto>> GetAllAsync()
        {
            return await this.context.Contacts
                .Select(c => new AllDto()
                {
                    ContactId = c.Id,
                    Address = c.Address ?? null,
                    Email = c.Email,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    PhoneNumber = c.PhoneNumber,
                    Website = c.Website
                })
                .ToListAsync();
        }

        public async Task<ICollection<AllDto>> GetAddedToTeamAsync(string userId)
        {
            ApplicationUser user = await FindUserById(userId);

            return user.ApplicationUsersContacts
                .Select(x => new AllDto()
                {
                    ContactId = x.Contact.Id,
                    Address = x.Contact.Address ?? null,
                    Email = x.Contact.Email,
                    FirstName = x.Contact.FirstName,
                    LastName = x.Contact.LastName,
                    PhoneNumber = x.Contact.PhoneNumber,
                    Website = x.Contact.Website
                }).ToList();
        }

        public async Task AddToTeam(int contactId, string userId)
        {
            ApplicationUser user = await FindUserById(userId);

            Contact contact = await context.Contacts
                .FirstOrDefaultAsync(c => c.Id == contactId)
                ?? throw new ArgumentNullException("Invalid contact ID");

            if (!user.ApplicationUsersContacts.Any(x => x.ContactId == contactId))
            {
                var applicationuserContact = new ApplicationUserContact()
                {
                    ContactId = contact.Id,
                    ApplicationUserId = user.Id
                };

                user.ApplicationUsersContacts.Add(applicationuserContact);
                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveFromTeam(int contactId, string userId)
        {
            ApplicationUser user = await FindUserById(userId);

            ApplicationUserContact contact = await context.ApplicationUsersContacts
                .FirstOrDefaultAsync(c => c.Contact.Id == contactId)
                ?? throw new ArgumentNullException("Invalid contact ID");

            if (contact != null)
            {
                user.ApplicationUsersContacts.Remove(contact);
                await context.SaveChangesAsync();
            }

        }

        private async Task<ApplicationUser> FindUserById(string userId)
         => await context.Users
                            .Where(u => u.Id == userId)
                            .Include(u => u.ApplicationUsersContacts)
                            .ThenInclude(u => u.Contact)
                            .FirstOrDefaultAsync()
                            ?? throw new ArgumentNullException("Invalid user ID");
    }
}
