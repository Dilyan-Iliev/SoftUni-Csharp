namespace Theatre.Data.Models
{
    using global::Theatre.Utils;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Cast
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CastFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        public bool IsMainCharacter { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(Play))]
        public int PlayId { get; set; }

        public virtual Play Play { get; set; }
    }
}
