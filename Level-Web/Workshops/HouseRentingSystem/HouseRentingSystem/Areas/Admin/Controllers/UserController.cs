namespace HouseRentingSystem.Areas.Admin.Controllers
{
    using HouseRentingSystem.Services.Interfaces.Admin;
    using Microsoft.AspNetCore.Mvc;

    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> All()
        {
            var model = await this.userService.All();

            return View(model);
        }
    }
}
