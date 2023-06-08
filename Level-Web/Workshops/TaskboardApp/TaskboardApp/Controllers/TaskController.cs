namespace TaskboardApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TaskboardApp.Extensions;
    using TaskboardApp.Services.Contracts;
    using TaskboardApp.ViewModels.Task;

    public class TaskController : BaseController
    {
        private readonly ITaskService taskService;
        private readonly IBoardService boardService;

        public TaskController(ITaskService taskService,
            IBoardService boardService)
        {
            this.taskService = taskService;
            this.boardService = boardService;
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddTaskViewModel()
            {
                Boards = await this.boardService.GetBoardsAsync(),
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Boards = await this.boardService.GetBoardsAsync();
                return this.View(model);
            }

            bool boardExist = await CheckForBoard<AddTaskViewModel>(model, m => m.BoardId);

            if (!boardExist)
            {
                ModelState.AddModelError(nameof(model.BoardId), "Board does not exist.");
            }

            var ownerId = this.User.GetById();
            await this.taskService.AddAsync(model, ownerId);

            return this.RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var task = await this.taskService.GetDetailsAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            return this.View(task);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await this.taskService.FindByIdAsync(id);

            if (task == null)
            {
                return this.BadRequest();
            }

            if (task.OwnerId != this.User.GetById())
            {
                return this.Unauthorized();
            }

            var model = new EditTaskViewModel()
            {
                Title = task.Title,
                Description = task.Description,
                Boards = await this.boardService.GetBoardsAsync()
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditTaskViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                model.Boards = await this.boardService.GetBoardsAsync();
                return this.View(model);
            }

            bool boardExist = await CheckForBoard<EditTaskViewModel>(model, m => m.BoardId);

            if (!boardExist)
            {
                ModelState.AddModelError(nameof(model.BoardId), "Board does not exist.");
            }

            //var ownerId = this.User.GetById();

            await this.taskService.EditAsync(model, id);
            return this.RedirectToAction("All", "Board");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this.taskService.DeleteAsync(id);
                return this.RedirectToAction("All", "Board");
            }
            catch
            {
                return this.BadRequest();
            }
        }

        private async Task<bool> CheckForBoard<T>(T model, Func<T, int> getBoardIdFunc)
        {
            //Func accepts T model and returns int

            var boards = await this.boardService.GetBoardsAsync();
            int modelBoardId = getBoardIdFunc(model);
            bool boardExist = boards.Any(b => b.Id == modelBoardId);
            return boardExist;
        }
    }
}
