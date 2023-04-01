namespace Boardgames.Data.Models
{
    using Boardgames.Constants;
    using System.ComponentModel.DataAnnotations;

    public class Creator
    {
        public Creator()
        {
            this.Boardgames = new HashSet<Boardgame>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CreatorNameMaxLength)]
        public string FirstName  { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CreatorNameMaxLength)]
        public string LastName { get; set; }

        public virtual ICollection<Boardgame> Boardgames { get; set; }
    }
}
