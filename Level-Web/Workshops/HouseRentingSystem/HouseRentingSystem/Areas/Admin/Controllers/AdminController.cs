namespace HouseRentingSystem.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}