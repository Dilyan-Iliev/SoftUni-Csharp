namespace HouseRentingSystem.Services.DTOs.Agent
{
    using System.ComponentModel.DataAnnotations;

    public class BecomeAgentDto
    {
        [Required]
        [StringLength(15, MinimumLength = 7)]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;
    }
}
