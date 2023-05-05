namespace Contacts.Services.DTOs
{
    using global::Contacts.Core.Constants;
    using System.ComponentModel.DataAnnotations;

    public class LoginDto
    {
        [Required(ErrorMessage = ErrorConstants.FieldRequiredError)]
        [StringLength(DataConstants.ApplicationUserConstants.UsernameMaxLength,
            MinimumLength = DataConstants.ApplicationUserConstants.UsernameMinLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
