namespace Theatre.Data.Models
{
    using global::Theatre.Utils;
    using System.ComponentModel.DataAnnotations;

    public class Theatre
    {
        public Theatre()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.TheatreNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.TheatreMaxNumberOfHalls)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MaxLength(GlobalConstants.TheatreDirectorNameMaxLength)]
        public string Director { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
