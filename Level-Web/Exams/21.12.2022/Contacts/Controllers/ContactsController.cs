namespace Contacts.Controllers
{
    using Contacts.Services.Contacts;
    using Contacts.Services.DTOs;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    public class ContactsController : BaseController
    {
        private readonly IContactsService contactsService;

        public ContactsController(IContactsService contactsService)
        {
            this.contactsService = contactsService;
        }

        public async Task<IActionResult> All()
        {
            var contacts = await this.contactsService.GetAllAsync();

            return View(contacts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new AddContactDto());
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddContactDto contactDto)
        {
            if (!ModelState.IsValid)
            {
                return View(contactDto);
            }

            await contactsService.AddContact(contactDto);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int contactId)
        {
            var post = await contactsService.FindByIdAsync(contactId);

            return View(new EditContactDto()
            {
                ContactId = post.Id,
                FirstName = post.FirstName,
                LastName = post.LastName,
                Email = post.Email,
                PhoneNumber = post.PhoneNumber,
                Address = post.Address ?? null,
                Website = post.Website,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int contactId, EditContactDto contactDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await this.contactsService.EditAsync(contactId, contactDto);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Team()
        {
            string userId = FindUserId();

            var addedContacts = await this.contactsService.GetAddedToTeamAsync(userId);

            return View(addedContacts);
        }

        [HttpPost]
        public async Task<IActionResult> AddToTeam(int contactId)
        {
            try
            {
                var userId = FindUserId();

                await this.contactsService.AddToTeam(contactId, userId);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction(nameof(Team));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromTeam(int contactId)
        {
            try
            {
                var userId = FindUserId();

                await this.contactsService.RemoveFromTeam(contactId, userId);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction(nameof(Team));
        }

        private string FindUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
