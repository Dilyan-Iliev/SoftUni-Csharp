namespace HouseRentingSystem.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static HouseRentingSystem.Areas.Admin.Constants.AdminConstants;

    [Area(AreaName)]
    //[Route("Admin/[controller]/[Action]/{id?}")] //освен в Program.cs раута, е нужно и тук да добавим това,
    //за да конкретизираме пътя на админ area-та.
    [Authorize(Roles = AdminRole)]
    public class BaseController : Controller
    {
    }
}