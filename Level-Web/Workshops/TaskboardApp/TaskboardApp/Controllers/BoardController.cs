namespace TaskboardApp.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TaskboardApp.Services.Contracts;

    public class BoardController : BaseController
    {
        private readonly IBoardService boardService;

        public BoardController(IBoardService boardService)
        {
            this.boardService = boardService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var boards = await this.boardService.GetAllAsync();

            return this.View(boards);
        }
    }
}
