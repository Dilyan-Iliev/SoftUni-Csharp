namespace Footballers.Data.Models
{
    using Footballers.Data.Models.Enums;
    using Footballers.GlobalConstants;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Footballer
    {
        public Footballer()
        {
            this.TeamsFootballers = new HashSet<TeamFootballer>();    
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(ModelConstants.FootballerNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public DateTime ContractStartDate { get; set; }

        [Required]
        public DateTime ContractEndDate { get; set; }

        [Required]
        public PositionType PositionType { get; set; }

        [Required]
        public BestSkillType BestSkillType { get; set; }

        [ForeignKey(nameof(Coach))]
        public int CoachId { get; set; }

        public virtual Coach Coach { get; set; }

        public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; }
    }
}
