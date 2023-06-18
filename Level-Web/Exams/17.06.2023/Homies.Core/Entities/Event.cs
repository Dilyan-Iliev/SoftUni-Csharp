namespace Homies.Core.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Homies.Common.DataConstants.EventConstants;

    public class Event
    {
        public Event()
        {
            this.EventsParticipants = new HashSet<EventParticipant>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Organiser))]
        public string OrganiserId { get; set; } = null!;

        public IdentityUser Organiser { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }

        public Type Type { get; set; } = null!;

        public ICollection<EventParticipant> EventsParticipants { get; set; }
    }
}
