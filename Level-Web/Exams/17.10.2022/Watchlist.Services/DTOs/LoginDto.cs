namespace Watchlist.Services.DTOs;

using System.ComponentModel.DataAnnotations;
using static Watchlist.Core.Data.Constants.DataConstants.UserConstants;
using static Watchlist.Core.Data.Constants.ErrorMessagesConstants;

public class LoginDto
{
    [Required(ErrorMessage = RequiredField)]
    [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage = RequiredField)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}
