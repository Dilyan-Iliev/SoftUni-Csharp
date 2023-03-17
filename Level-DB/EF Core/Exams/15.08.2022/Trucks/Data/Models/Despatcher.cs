namespace Trucks.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Trucks.GlobalConstants;

    public class Despatcher
    {
        public Despatcher()
        {
            this.Trucks = new HashSet<Truck>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(ModelContants.DespatcherNameMaxLength)]
        public string Name { get; set; }

        public string Position { get; set; }

        public virtual ICollection<Truck> Trucks { get; set; }
    }
}
