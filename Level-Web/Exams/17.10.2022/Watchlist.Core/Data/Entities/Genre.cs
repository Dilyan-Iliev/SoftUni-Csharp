namespace Watchlist.Core.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using static Watchlist.Core.Data.Constants.DataConstants.GenreConstants;

    public class Genre
    {
        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
