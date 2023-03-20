namespace Theatre.Data.Models
{
    using global::Theatre.Data.Models.Enums;
    using global::Theatre.Utils;
    using System.ComponentModel.DataAnnotations;

    public class Play
    {
        public Play()
        {
            this.Casts = new HashSet<Cast>();
            this.Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PlayTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        public float Rating { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PlayDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PlayScreenWriterNameMaxLength)]
        public string Screenwriter { get; set; }

        public virtual ICollection<Cast> Casts { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
