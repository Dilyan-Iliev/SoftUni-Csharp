namespace SoftUniBazar.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SoftUniBazar.Extensions;
    using SoftUniBazar.Models;
    using SoftUniBazar.Services;

    public class AdController : BaseController
    {
        private readonly IAdService adService;

        public AdController(IAdService adService)
        {
            this.adService = adService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await this.adService.GetAllAdsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new CreateAdViewModel()
            {
                Categories = await this.adService.RetrieveCategoriesAsync()
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateAdViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.adService.RetrieveCategoriesAsync();
                return View(model);
            }

            string creatorId = this.User.GetById();
            await this.adService.AddNewAdAsync(model, creatorId);

            return this.RedirectToAction(nameof(Cart), "Ad");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var adForEdit = await this.adService.FindAdForEditAsync(id);

            var model = new EditAdViewModel()
            {
                Name = adForEdit.Name,
                Description = adForEdit.Description,
                ImageUrl = adForEdit.ImageUrl,
                Price = adForEdit.Price,
                CategoryId = adForEdit.CategoryId,
                Categories = await this.adService.RetrieveCategoriesAsync()
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditAdViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.adService.EditAdAsync(id, model);
            return this.RedirectToAction(nameof(All), "Ad");
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            string userId = this.User.GetById();
            var model = await this.adService.GetAdsInCartAsync(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            string userId = this.User.GetById();
            int result = await this.adService.AddToCartAsync(id, userId);

            if (result == 1)
            {
                return this.RedirectToAction(nameof(Cart), "Ad");
            }

            return this.RedirectToAction(nameof(All), "Ad");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            string userId = this.User.GetById();
            await this.adService.RemoveFromCartAsync(id, userId);

            return RedirectToAction(nameof(All), "Ad");
        }
    }
}
