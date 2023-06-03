namespace HouseRentingSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using HouseRentingSystem.Services.DTOs.House;
    using HouseRentingSystem.Services.Interfaces;
    using HouseRentingSystem.Extensions;

    public class HousesController : BaseController
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;

        public HousesController(
            IHouseService houseService,
            IAgentService agentService)
        {
            this.houseService = houseService;
            this.agentService = agentService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View();
        }

        public async Task<IActionResult> Mine()
        {


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool userIdExists =
                await this.agentService.ExistsByIdAsync(this.User.Id());

            if (!userIdExists)
            {
                //агент може само да добавя имоти и ако не е агент - препращаме към страницата да стане агент
                return RedirectToAction(nameof(AgentController.Become), "Agent");
            }

            var model = new AddHouseDto()
            {
                Categories = await this.houseService.GetHouseCategories(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddHouseDto model)
        {
            bool userIdExists =
               await this.agentService.ExistsByIdAsync(this.User.Id());

            if (!userIdExists)
            {
                return RedirectToAction(nameof(AgentController.Become), "Agent");
            }

            bool categoryIdExists =
                await this.houseService.CategoryExists(model.CategoryId);

            if (!categoryIdExists)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await this.houseService.GetHouseCategories();
                return View(model);
            }

            int agentId = await this.agentService.GetAgentId(this.User.Id());

            int id = await this.houseService.Add(model, agentId);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new EditHouseDto();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditHouseDto model)
        {
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
