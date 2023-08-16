namespace SoftUniBazar.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Ad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(250)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; } = null!;

        //[Required]
        public IdentityUser Owner { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
