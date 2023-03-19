namespace Artillery.Data.Models
{
    using Artillery.Utils;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        public Country()
        {
            this.CountriesGuns = new HashSet<CountryGun>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CountryNameMaxLength)]
        public string CountryName { get; set; }

        [MaxLength(GlobalConstants.CountryArmSizeMaxLength)]
        public int ArmySize { get; set; }

        public virtual ICollection<CountryGun> CountriesGuns { get; set; }
    }
}
