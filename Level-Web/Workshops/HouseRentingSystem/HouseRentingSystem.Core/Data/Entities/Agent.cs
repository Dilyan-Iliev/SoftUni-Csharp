namespace HouseRentingSystem.Core.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static HouseRentingSystem.Common.DataConstants.AgentConstants;

    public class Agent
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public IdentityUser User { get; set; } = null!;
    }
}
