namespace ForumAppDemo.Controllers
{
    using ForumAppDemo.Models;
    using ForumAppDemo.Services.Contracts;
    using ForumAppDemo.Services.DTOs;
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : Controller
    {
        private readonly IPostsService postsService;
        public PostsController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        public async Task<IActionResult> All()
        {
            ViewData["Title"] = "All Posts";

            var posts = await postsService.GetAll();
            return View(posts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPostModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View();
            }

            await postsService.AddPost(model);
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await postsService.DeletePost(id);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var postForEdit = await this.postsService.FindPost(id);

            return View(new PostViewModel()
            {
                Title = postForEdit.Title,
                Content = postForEdit.Content
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,PostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await this.postsService.EditPost(id, model);

            return RedirectToAction(nameof(All));
        }
    }
}
