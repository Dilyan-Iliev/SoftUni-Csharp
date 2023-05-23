namespace HouseRentingSystem.Controllers
{
    using HouseRentingSystem.Services.DTOs.Agent;
    using Microsoft.AspNetCore.Mvc;

    public class AgentController : BaseController
    {
        [HttpGet]
        public IActionResult Become()
        {
            return View();
        }


        public async Task<IActionResult> Become(BecomeAgentDto model)
        {
            return RedirectToAction("All", "Houses");
        }
    }
}
