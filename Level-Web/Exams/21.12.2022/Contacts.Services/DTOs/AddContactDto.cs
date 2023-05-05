namespace Contacts.Services.DTOs
{
    using global::Contacts.Core.Constants;
    using System.ComponentModel.DataAnnotations;

    public class AddContactDto
    {
        [Required(ErrorMessage = ErrorConstants.FieldRequiredError)]
        [StringLength(DataConstants.ContactConstants.FirstNameMaxLength,
            MinimumLength = DataConstants.ContactConstants.LastNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = ErrorConstants.FieldRequiredError)]
        [StringLength(DataConstants.ContactConstants.LastNameMaxLength,
            MinimumLength = DataConstants.ContactConstants.LastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = ErrorConstants.FieldRequiredError)]
        [StringLength(DataConstants.ContactConstants.EmailMaxLength,
            MinimumLength = DataConstants.ContactConstants.EmailMinLength)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = ErrorConstants.FieldRequiredError)]
        [RegularExpression(DataConstants.ContactConstants.PhonNumberRegex)]
        [StringLength(DataConstants.ContactConstants.PhoneMaxLength,
            MinimumLength = DataConstants.ContactConstants.PhoneMinLength)]
        public string PhoneNumber { get; set; } = null!;

        public string? Address { get; set; }

        [Required(ErrorMessage = ErrorConstants.FieldRequiredError)]
        [RegularExpression(DataConstants.ContactConstants.WebsiteRegex)]
        public string Website { get; set; } = null!;
    }
}
