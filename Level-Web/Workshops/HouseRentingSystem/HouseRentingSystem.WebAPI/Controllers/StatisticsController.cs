namespace HouseRentingSystem.WebAPI.Controllers
{
    using HouseRentingSystem.Services.DTOs.Statistics;
    using HouseRentingSystem.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        /// <summary>
        /// Gets statistics about number of houses and rented houses
        /// </summary>
        /// <returns>Total houses and total rents</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(StatisticsServiceModel))]
        public async Task<IActionResult> GetStatistics()
        {
            var statistics = await this.statisticsService.Total();

            return Ok(statistics);
        } 
    }
}
