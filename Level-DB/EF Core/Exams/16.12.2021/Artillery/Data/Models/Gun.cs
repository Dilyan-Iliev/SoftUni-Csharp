namespace Artillery.Data.Models
{
    using Artillery.Data.Models.Enums;
    using Artillery.Utils;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Gun
    {
        public Gun()
        {
            this.CountriesGuns = new HashSet<CountryGun>();
        }

        public int Id { get; set; }

        [ForeignKey(nameof(Manufacturer))]
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [MaxLength(GlobalConstants.GunMaxWeight)]
        public int GunWeight { get; set; }

        //[MaxLength((int)GlobalConstants.GunBarrelMaxLength)]
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        [MaxLength(GlobalConstants.GunMaxRange)]
        public int Range { get; set; }

        [Required]
        public GunType GunType { get; set; }

        [ForeignKey(nameof(Shell))]
        public int ShellId { get; set; }

        public virtual Shell Shell { get; set; }

        public virtual ICollection<CountryGun> CountriesGuns { get; set; }
    }
}
