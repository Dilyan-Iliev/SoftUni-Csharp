namespace Watchlist.Services.DTOs;

using System.ComponentModel.DataAnnotations;
using static Watchlist.Core.Data.Constants.DataConstants.UserConstants;
using static Watchlist.Core.Data.Constants.ErrorMessagesConstants;

public class RegisterDto
{
    [Required(ErrorMessage = RequiredField)]
    [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage = RequiredField)]
    [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = RequiredField)]
    [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = PasswordMissmatch)]
    public string ConfirmPassword { get; set; } = null!;
}
