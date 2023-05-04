namespace Watchlist.Services.Contracts
{
    using Watchlist.Core.Data.Entities;
    using Watchlist.Services.DTOs;


    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetAllAsync();

        Task AddAsync(AddMovieDto viewModel);

        Task<ICollection<Genre>> GetGenresAsync();

        Task AddToCollectionAsync(int movieId, string userId);

        Task RemoveFromCollectionAsync(int movieId, string userId);

        Task<IEnumerable<MovieDto>> GetWatchedAsync(string userId);

    }
}
