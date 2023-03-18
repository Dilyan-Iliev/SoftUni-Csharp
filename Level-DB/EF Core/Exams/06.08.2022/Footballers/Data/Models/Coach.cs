namespace Footballers.Data.Models
{
    using Footballers.GlobalConstants;
    using System.ComponentModel.DataAnnotations;

    public class Coach
    {
        public Coach()
        {
            this.Footballers = new HashSet<Footballer>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(ModelConstants.CoachNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Nationality { get; set; }

        public ICollection<Footballer> Footballers { get; set; }
    }
}
