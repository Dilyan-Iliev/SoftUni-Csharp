namespace Watchlist.Services.DTOs;

using System.ComponentModel.DataAnnotations;
using static Watchlist.Core.Data.Constants.DataConstants.MovieConstants;
using Watchlist.Core.Data.Entities;

public class AddMovieDto
{
    public AddMovieDto()
    {
        this.Genres = new List<Genre>();
    }

    [Required]
    [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(DirectorMaxLength, MinimumLength = DirectorMinLength)]
    public string Director { get; set; } = null!;

    [Required]
    public string ImageUrl { get; set; } = null!;

    [Range(typeof(decimal), "0.00", "10.00",
        ConvertValueInInvariantCulture = true)]
    public decimal Rating { get; set; }

    public int GenreId { get; set; }

    public ICollection<Genre> Genres { get; set; }
}
