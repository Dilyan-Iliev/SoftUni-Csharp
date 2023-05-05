namespace Contacts.Services.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using global::Contacts.Core.Constants;

    public class RegisterDto
    {
        [Required(ErrorMessage = ErrorConstants.FieldRequiredError)]
        [StringLength(DataConstants.ApplicationUserConstants.UsernameMaxLength,
            MinimumLength = DataConstants.ApplicationUserConstants.UsernameMinLength)]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = ErrorConstants.FieldRequiredError)]
        [StringLength(DataConstants.ApplicationUserConstants.EmailMaxLength,
            MinimumLength = DataConstants.ApplicationUserConstants.EmailMinLength)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = ErrorConstants.FieldRequiredError)]
        [StringLength(DataConstants.ApplicationUserConstants.PasswordMaxLength,
            MinimumLength = DataConstants.ApplicationUserConstants.PasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = ErrorConstants.FieldRequiredError)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
