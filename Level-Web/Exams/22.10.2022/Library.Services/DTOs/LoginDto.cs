namespace Library.Services.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using static Library.Common.ErrorConstants;

    public class LoginDto
    {
        [Required(ErrorMessage = FieldRequired)]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = FieldRequired)]
        public string Password { get; set; } = null!;
    }
}
