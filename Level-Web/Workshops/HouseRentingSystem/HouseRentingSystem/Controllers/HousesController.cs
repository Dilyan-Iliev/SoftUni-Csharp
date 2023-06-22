namespace HouseRentingSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using HouseRentingSystem.Services.DTOs.House;
    using HouseRentingSystem.Services.Interfaces;
    using HouseRentingSystem.Extensions;
    using System.Runtime.CompilerServices;
    using HouseRentingSystem.Services.Extensions;

    public class HousesController : BaseController
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;
        private readonly ILogger<HousesController> logger;

        public HousesController(
            IHouseService houseService,
            IAgentService agentService,
            ILogger<HousesController> logger)
        {
            this.houseService = houseService;
            this.agentService = agentService;
            this.logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllHousesQueryModel query)
        //[FromQuery] е, тъй като във формата на самото All View имаме форма с метод GET 
        {
            var result = await this.houseService.All(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllHousesQueryModel.HousesPerPage);

            query.TotalHousesCount = result.TotalHouses;
            query.Categories = await this.houseService.AllCategoriesNames();
            query.Houses = result.Houses;

            return this.View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            IEnumerable<HouseServiceModel> myHouses;

            string userId = this.User.Id();

            bool isAgent = await this.agentService.ExistsByIdAsync(userId);

            if (isAgent)
            {
                int agentId = await this.agentService.GetAgentId(userId);
                myHouses = await this.houseService.AllHousesByAgentId(agentId);
            }
            else
            {
                myHouses = await this.houseService.AllHousesByUserId(userId);
            }

            return this.View(myHouses);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool userIdExists =
                await this.agentService.ExistsByIdAsync(this.User.Id());

            if (!userIdExists)
            {
                //агент може само да добавя имоти и ако не е агент - препращаме към страницата да стане агент
                return this.RedirectToAction(nameof(AgentController.Become), "Agent");
            }

            var model = new AddHouseDto()
            {
                Categories = await this.houseService.GetHouseCategories(),
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddHouseDto model)
        {
            bool userIdExists =
               await this.agentService.ExistsByIdAsync(this.User.Id());

            if (!userIdExists)
            {
                return this.RedirectToAction(nameof(AgentController.Become), "Agent");
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
                return this.View(model);
            }

            int agentId = await this.agentService.GetAgentId(this.User.Id());

            int id = await this.houseService.Add(model, agentId);

            return this.RedirectToAction(nameof(Details), new { id, information = model.GetInformation() });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, string information)
        {
            bool houseExist = await this.houseService.Exists(id);

            if (!houseExist)
            {
                return this.RedirectToAction(nameof(All));

            }

            var house = await this.houseService.HouseDetailsById(id);

            if (information != house.GetInformation())
            {
                TempData["ErrorMessage"] = "Don't touch my slug";

                return this.RedirectToAction("Index", "Home");
            }

            return this.View(house);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool houseExists = await this.houseService.Exists(id);

            if (!houseExists)
            {
                return this.RedirectToAction(nameof(All));
            }

            bool agentWithIdExists = await this.houseService.HasAgentWithId(id, this.User.Id());

            if (!agentWithIdExists)
            {
                this.logger.LogWarning($"User with id {this.User.Id()} attempted to open other agent house");

                return this.RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            var house = await this.houseService.HouseDetailsById(id);
            var categoryId = await this.houseService.GetHouseCategoryId(id);

            var model = new AddHouseDto()
            {
                Id = house.Id,
                Address = house.Address,
                ImageUrl = house.ImageUrl,
                Description = house.Description,
                Title = house.Title,
                PricePerMonth = house.PricePerMonth,
                CategoryId = categoryId,
                Categories = await this.houseService.GetHouseCategories()
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddHouseDto model)
        {
            if (id != model.Id)
            {
                return this.RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.houseService.GetHouseCategories();
                return this.View(model);
            }

            bool houseExists = await this.houseService.Exists(model.Id);

            if (!houseExists)
            {
                this.ModelState.AddModelError(string.Empty, "House does not exist");

                model.Categories = await this.houseService.GetHouseCategories();
                return this.View(model);
            }

            bool agentWithIdExists = await this.houseService.HasAgentWithId(model.Id, this.User.Id());

            if (!agentWithIdExists)
            {
                return this.RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            bool categoryExists = await this.houseService.CategoryExists(model.CategoryId);

            if (!categoryExists)
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");

                model.Categories = await this.houseService.GetHouseCategories();
                return this.View(model);
            }

            await this.houseService.Edit(model.Id, model);

            return this.RedirectToAction(nameof(Details), new { id = model.Id, information = model.GetInformation() });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            bool houseExists = await this.houseService.Exists(id);

            if (!houseExists)
            {
                return this.RedirectToAction(nameof(All));
            }

            bool agentWithIdExists = await this.houseService.HasAgentWithId(id, this.User.Id());

            if (!agentWithIdExists)
            {
                return this.RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            var house = await this.houseService.HouseDetailsById(id);
            var model = new DeleteHouseViewModel()
            {
                Address = house.Address,
                ImageUrl = house.ImageUrl,
                Title = house.Title
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, DeleteHouseViewModel model)
        {
            bool houseExists = await this.houseService.Exists(id);

            if (!houseExists)
            {
                return this.RedirectToAction(nameof(All));
            }

            bool agentWithIdExists = await this.houseService.HasAgentWithId(id, this.User.Id());

            if (!agentWithIdExists)
            {
                return this.RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            await this.houseService.Delete(id);

            return this.RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            bool houseExists = await this.houseService.Exists(id);

            if (!houseExists)
            {
                return this.RedirectToAction(nameof(All));
            }

            bool agentWithIdExists = await this.agentService.ExistsByIdAsync(this.User.Id());

            if (agentWithIdExists)
            {
                return this.RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            var isHouseRented = await this.houseService.IsRented(id);

            if (isHouseRented)
            {
                return this.RedirectToAction(nameof(All));
            }

            await this.houseService.Rent(id, this.User.Id());

            return this.RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            bool houseExists = await this.houseService.Exists(id);
            var isHouseRented = await this.houseService.IsRented(id);

            if (!houseExists || !isHouseRented)
            {
                return this.RedirectToAction(nameof(All));
            }

            bool isHouseRentedByUser = await this.houseService.IsRentedByUserWithId(this.User.Id(), id);

            if (!isHouseRentedByUser)
            {
                return this.RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            await this.houseService.Leave(id);

            return this.RedirectToAction(nameof(Mine));
        }
    }
}
