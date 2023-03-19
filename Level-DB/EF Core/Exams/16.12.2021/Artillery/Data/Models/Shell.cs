namespace Artillery.Data.Models
{
    using Artillery.Utils;
    using System.ComponentModel.DataAnnotations;

    public class Shell
    {
        public Shell()
        {
            this.Guns = new HashSet<Gun>();
        }

        public int Id { get; set; }

       // [MaxLength((int)GlobalConstants.ShellMaxWeight)]
        public double ShellWeight { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ShellCaliberMaxLength)]
        public string Caliber { get; set; }

        public virtual ICollection<Gun> Guns { get; set; }
    }
}
