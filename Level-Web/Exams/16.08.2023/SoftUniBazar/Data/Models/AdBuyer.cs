namespace SoftUniBazar.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AdBuyer
    {
        [Required]
        [ForeignKey(nameof(Buyer))]
        public string BuyerId { get; set; } = null!;

        public virtual IdentityUser Buyer { get; set; } = null!;

        [ForeignKey(nameof(Ad))]
        public int AdId { get; set; }

        public Ad Ad { get; set; }
    }
}
