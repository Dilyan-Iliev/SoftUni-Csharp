namespace TaskboardApp.ViewModels.Account
{
    using Microsoft.AspNetCore.Authentication;
    using System.ComponentModel.DataAnnotations;
    using static TaskboardApp.Common.ErrorConstants;

    public class LoginViewModel
    {
        public LoginViewModel()
        {
            this.ExternalLogins = new List<AuthenticationScheme>();
        }

        [Required(ErrorMessage = FieldRequired)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = FieldRequired)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        //for external login
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
