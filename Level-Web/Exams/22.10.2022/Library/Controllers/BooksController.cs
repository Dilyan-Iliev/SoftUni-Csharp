namespace Library.Controllers
{
    using Library.Services.Contracts;
    using Library.Services.DTOs;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    public class BooksController : BaseController
    {
        private readonly IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var allBooks = await this.booksService
                .GetAllAsync();

            return View(allBooks);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await this.booksService
                .GetCategoriesAsync();

            var book = new AddBookDto
            {
                Categories = categories
            };

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return View(bookDto);
            }

            await this.booksService.AddNewAsync(bookDto);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            string userId = GetUserId();

            var myBooks = await this.booksService.GetMyBooksAsync(userId);

            return View(myBooks);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {
            string userId = GetUserId();
            await this.booksService.AddToCollection(userId, bookId);

            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            string userId = GetUserId();
            await this.booksService.RemoveFromCollection(userId, bookId);

            return RedirectToAction(nameof(Mine));
        }

        private string GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
