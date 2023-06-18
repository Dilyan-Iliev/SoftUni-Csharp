namespace Homies.Controllers
{
    using Homies.Extensions;
    using Homies.Services.Contracts;
    using Homies.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class EventController : BaseController
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return this.View(new AddEventViewModel()
            {
                Types = await this.eventService.GetEventTypesAsync(),
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var organiserId = this.User.GetById();

            await this.eventService.AddAsync(model, organiserId);

            return this.RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var events = await this.eventService.GetAllForCreatorAsync();

            return this.View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var eventForEdit = await this.eventService.FindByIdAsync(id);

            return this.View(new EditEventViewModel()
            {
                Id = eventForEdit.Id,
                Name = eventForEdit.Name,
                Description = eventForEdit.Description,
                Start = eventForEdit.Start,
                End = eventForEdit.End,
                TypeId = eventForEdit.TypeId,
                Types = await this.eventService.GetEventTypesAsync(),
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditEventViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.eventService.EditAsync(id, model);

            return this.RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await this.eventService.GetDetailsAsync(id);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var userId = this.User.GetById();
            var result = await this.eventService.JoinAsync(id, userId);

            if (result == 1)
            {
                return this.RedirectToAction(nameof(Joined));
            }

            return this.RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            var userId = this.User.GetById();
            var result = await this.eventService.GetAllJoinedEventsAsync(userId);

            return this.View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            var userId = this.User.GetById();
            await this.eventService.LeaveAsync(id, userId);

            return this.RedirectToAction(nameof(All));
        }
    }
}
