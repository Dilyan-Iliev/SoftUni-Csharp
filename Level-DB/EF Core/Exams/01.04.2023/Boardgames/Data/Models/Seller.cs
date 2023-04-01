namespace Boardgames.Data.Models
{
    using Boardgames.Constants;
    using System.ComponentModel.DataAnnotations;

    public class Seller
    {
        public Seller()
        {
            this.BoardgamesSellers = new HashSet<BoardgameSeller>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.SellerNameMaxlength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(GlobalConstants.SellerAddressMaxLength)]
        public string Address { get; set; }

        [Required]  
        public string Country { get; set; }

        [Required]
        public string Website { get; set; }

        public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
    }
}
