namespace SoftUniBazar.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
            this.Ads = new HashSet<Ad>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Ad> Ads { get; set; }
    }
}
