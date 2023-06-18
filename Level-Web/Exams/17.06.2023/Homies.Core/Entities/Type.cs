namespace Homies.Core.Entities
{
    using System.ComponentModel.DataAnnotations;

    using static Homies.Common.DataConstants.TypeConstants;

    public class Type
    {
        public Type()
        {
            this.Events = new HashSet<Event>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Event> Events { get; set; }
    }
}
