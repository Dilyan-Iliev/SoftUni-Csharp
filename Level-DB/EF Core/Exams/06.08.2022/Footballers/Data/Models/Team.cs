namespace Footballers.Data.Models
{
    using Footballers.GlobalConstants;
    using System.ComponentModel.DataAnnotations;

    public class Team
    {
        public Team()
        {
            this.TeamsFootballers = new HashSet<TeamFootballer>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(ModelConstants.TeamNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ModelConstants.TeamNationalityMaxLength)]
        public string Nationality { get; set; }

        public int Trophies { get; set; }

        public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; }
    }
}
