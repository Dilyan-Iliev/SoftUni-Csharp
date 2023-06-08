namespace TaskboardApp.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using static TaskboardApp.Common.ErrorConstants;
    using static TaskboardApp.Common.DataConstants.AccountConstants;

    public class RegisterViewModel
    {
        [Required(ErrorMessage = FieldRequired)]
        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength,
            ErrorMessage = FieldLengthError)]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = FieldRequired)]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength,
            ErrorMessage = FieldLengthError)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = FieldRequired)]
        [DataType(DataType.Password)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength,
            ErrorMessage = FieldLengthError)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = FieldRequired)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = PasswordMissmatch)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
