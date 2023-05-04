namespace Watchlist.Services
{
    using Microsoft.EntityFrameworkCore;
    using Watchlist.Core.Data;
    using Watchlist.Core.Data.Entities;
    using Watchlist.Services.DTOs;
    using Watchlist.Services.Contracts;

    public class MovieService
        : IMovieService
    {
        private readonly WatchlistDbContext context;

        public MovieService(WatchlistDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(AddMovieDto viewModel)
        {
            Movie movie = new Movie()
            {
                Director = viewModel.Director,
                ImageUrl = viewModel.ImageUrl,
                Rating = viewModel.Rating,
                Title = viewModel.Title,
                GenreId = viewModel.GenreId,
            };

            await this.context.Movies.AddAsync(movie);
            await this.context.SaveChangesAsync();
        }

        public async Task AddToCollectionAsync(int movieId, string userId)
        {
            User user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync()
                ?? throw new ArgumentException("Invalid user ID");

            //var user = await context.Users
            //    .FirstOrDefaultAsync(u => u.Id == userId)
            //    ?? throw new ArgumentException("Invalid user ID");

            var movie = await context.Movies
                .FirstOrDefaultAsync(m => m.Id == movieId)
                ?? throw new ArgumentException("Invalid movie ID");

            if (!user.UsersMovies.Any(m => m.MovieId == movieId))
            {
                var userMovie = new UserMovie()
                {
                    MovieId = movie.Id,
                    UserId = user.Id
                };

                user.UsersMovies.Add(userMovie);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MovieDto>> GetAllAsync()
        {
            return await this.context.Movies
                .Select(m => new MovieDto()
                {
                    Id = m.Id,
                    ImageUrl = m.ImageUrl,
                    Title = m.Title,
                    Director = m.Director,
                    Rating = m.Rating,
                    Genre = m.Genre.Name
                })
                .ToListAsync();
        }

        public async Task<ICollection<Genre>> GetGenresAsync()
        {
            return await context.Genres
                .ToListAsync();
        }

        public async Task<IEnumerable<MovieDto>> GetWatchedAsync(string userId)
        {
            User user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .ThenInclude(um => um.Movie)
                .ThenInclude(u => u.Genre)
                .FirstOrDefaultAsync()
                ?? throw new ArgumentException("Invalid user ID");

            //връща само филмите, които потребителя е гледал
            return user.UsersMovies
                .Select(x => new MovieDto()
                {
                    Director = x.Movie.Director,
                    ImageUrl = x.Movie.ImageUrl,
                    Rating = x.Movie.Rating,
                    Title = x.Movie.Title,
                    Genre = x.Movie.Genre.Name,
                    Id = x.Movie.Id
                });
        }

        public async Task RemoveFromCollectionAsync(int movieId, string userId)
        {
            User user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync()
                ?? throw new ArgumentException("Invalid user ID");

            var movieToRemove = user.UsersMovies
                .FirstOrDefault(m => m.Movie.Id == movieId);

            if (movieToRemove != null)
            {
                user.UsersMovies.Remove(movieToRemove);
                await context.SaveChangesAsync();
            }
        }
    }
}
