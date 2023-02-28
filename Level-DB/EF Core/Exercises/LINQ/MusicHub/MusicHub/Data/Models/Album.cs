namespace MusicHub.Data.Models
{
    using MusicHub.Common;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Album
    {
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }

        public int Id { get; set; }

        [MaxLength(GlobalModelConstants.AlbumNameMaxLength)]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal Price
            => this.Songs.Sum(s => s.Price);

        [ForeignKey(nameof(Producer))]
        public int? ProducerId { get; set; }
        
        public virtual Producer Producer { get; set; }

        public virtual ICollection<Song> Songs { get; set; }

    }
}
