namespace Watchlist.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using Watchlist.Services.DTOs;
    using Watchlist.Services.Contracts;

    public class MoviesController : BaseController
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var movies = await this.movieService.GetAllAsync();

            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddMovieDto()
            {
                Genres = await movieService.GetGenresAsync(),
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMovieDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await movieService.AddAsync(model);
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something wen wrong");
                return View(model);
            }
        }

        public async Task<IActionResult> AddToCollection(int movieId)
        {
            try
            {
                var userId = User.Claims
                    .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?
                    .Value;
                //така вземам id-то на потребителя

                await movieService.AddToCollectionAsync(movieId, userId);

            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(Watched));
        }

        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            try
            {
                var userId = User.Claims
                    .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?
                    .Value;

                await this.movieService.RemoveFromCollectionAsync(movieId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(Watched));
        }

        public async Task<IActionResult> Watched()
        {
            var userId = User.Claims
                    .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?
                    .Value;

            var watchedMovies = await this.movieService.GetWatchedAsync(userId);

            return View(watchedMovies);
        }
    }
}
