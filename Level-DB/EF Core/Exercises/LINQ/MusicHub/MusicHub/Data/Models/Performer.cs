namespace MusicHub.Data.Models
{
    using MusicHub.Common;
    using System.ComponentModel.DataAnnotations;

    public class Performer
    {
        public Performer()
        {
            this.PerformerSongs = new HashSet<SongPerformer>();
        }

        public int Id { get; set; }

        [MaxLength(GlobalModelConstants.PerformerNameMaxLength)]
        public string FirstName { get; set; }

        [MaxLength(GlobalModelConstants.PerformerNameMaxLength)]
        public string LastName { get; set; }    

        public int Age { get; set; }

        public decimal NetWorth { get; set; }

        public virtual ICollection<SongPerformer> PerformerSongs { get; set; }
    }
}
