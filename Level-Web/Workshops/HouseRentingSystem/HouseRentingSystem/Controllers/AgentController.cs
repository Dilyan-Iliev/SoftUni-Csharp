namespace HouseRentingSystem.Controllers
{
    using HouseRentingSystem.Extensions;
    using HouseRentingSystem.Services.DTOs.Agent;
    using HouseRentingSystem.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    public class AgentController : BaseController
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService agentService)
        {
            this.agentService = agentService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string userId = this.User.Id();

            if (await agentService.ExistsByIdAsync(userId))
            {
                return BadRequest();
            }

            var model = new BecomeAgentDto();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentDto model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            string userId = User.Id();

            if (await agentService.ExistsByIdAsync(userId))
            {
                return BadRequest();
            }

            if (await agentService.UserWithPhoneNumberExistsAsync(model.PhoneNumber))
            {
                this.ModelState.AddModelError(nameof(model.PhoneNumber), "Phone number already exists. Enter another one.");
            }

            if (await agentService.UserHasRentsAsync(userId))
            {
                this.ModelState.AddModelError("Error", "You should have no rents to become an agent!");
            }

            await agentService.CreateAsync(userId, model.PhoneNumber);

            return RedirectToAction("All", "Houses");
        }
    }
}
