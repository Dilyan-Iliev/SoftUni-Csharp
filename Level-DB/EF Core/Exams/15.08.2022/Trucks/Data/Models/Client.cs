namespace Trucks.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Trucks.GlobalConstants;

    public class Client
    {
        public Client()
        {
            this.ClientsTrucks = new HashSet<ClientTruck>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(ModelContants.ClientNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ModelContants.ClientNationalityMaxLength)]
        public string Nationality { get; set; }

        [Required]
        public string Type { get; set; }

        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }
    }
}
