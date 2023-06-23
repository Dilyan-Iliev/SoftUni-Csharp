namespace HouseRentingSystem.Areas.Admin.Controllers
{
    using HouseRentingSystem.Areas.Admin.Models;
    using HouseRentingSystem.Extensions;
    using HouseRentingSystem.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    public class HouseController : BaseController
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;

        public HouseController(IAgentService agentService, IHouseService houseService)
        {
            this.agentService = agentService;
            this.houseService = houseService;
        }

        public async Task<IActionResult> Mine()
        {
            var myHouses = new MyHousesViewModel();
            var adminId = this.User.Id();

            myHouses.RentedHouses = await this.houseService.AllHousesByUserId(adminId);

            var agentId = await this.agentService.GetAgentId(adminId);
            myHouses.AddedHouses = await this.houseService.AllHousesByAgentId(agentId);

            return this.View(myHouses);
        }
    }
}
