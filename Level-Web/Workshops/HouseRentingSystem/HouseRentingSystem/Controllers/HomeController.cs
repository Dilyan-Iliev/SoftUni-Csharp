namespace HouseRentingSystem.Controllers
{
    using HouseRentingSystem.Models;
    using HouseRentingSystem.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using static HouseRentingSystem.Areas.Admin.Constants.AdminConstants;

    public class HomeController : BaseController
    {
        private readonly IHouseService houseService;

        public HomeController(IHouseService houseService)
        {
            this.houseService = houseService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole(AdminRole))
            {
                return this.RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

            var lastThreeHouses = await this.houseService.GetLastThreeHouses();

            return View(lastThreeHouses);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
          => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}