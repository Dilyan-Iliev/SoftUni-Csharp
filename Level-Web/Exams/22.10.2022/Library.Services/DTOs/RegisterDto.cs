namespace Library.Services.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using static Library.Common.DataConstants.ApplicationUserConstants;
    using static Library.Common.ErrorConstants;

    public class RegisterDto
    {
        [Required(ErrorMessage = FieldRequired)]
        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength,
            ErrorMessage = FieldCharactersLength)]

        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = FieldRequired)]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength,
            ErrorMessage = FieldCharactersLength)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = FieldRequired)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength,
            ErrorMessage = FieldCharactersLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = FieldRequired)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
