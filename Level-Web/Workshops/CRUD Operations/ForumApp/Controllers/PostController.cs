namespace ForumApp.Controllers
{
    using AspNetCoreHero.ToastNotification.Abstractions;
    using ForumApp.Services.Contracts;
    using ForumApp.Services.DTOs;
    using Microsoft.AspNetCore.Mvc;

    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly INotyfService notyfService;

        public PostController(IPostService postService, INotyfService notyfService)
        {
            this.postService = postService;
            this.notyfService = notyfService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var posts = await this.postService.AllAsync();

            return View(posts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new AddPostDto());
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPostDto model)
        {
            if (!this.ModelState.IsValid)
            {
                this.notyfService.Error("You have field errors");
                return View(model);
            }

            try
            {
                await this.postService.AddAsync(model);

                this.notyfService.Success("Successfully added a post");

                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occured while adding your post");
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var postForEdit = await this.postService.FindByIdAsync(id);

            return View(new EditPostDto()
            {
                Title = postForEdit.Title,
                Content = postForEdit.Content,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditPostDto model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await this.postService.EditAsync(id, model);

                this.notyfService.Success("Successfully edited a post");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occured while edditing your post");
                return View(model);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this.postService.DeleteAsync(id);

                this.notyfService.Success("Successfully deleted a post");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occured while deleting your post");
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
