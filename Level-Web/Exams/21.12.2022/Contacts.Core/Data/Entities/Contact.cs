namespace Contacts.Core.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using static Contacts.Core.Constants.DataConstants.ContactConstants;

    public class Contact
    {
        public Contact()
        {
            this.ApplicationUsersContacts = new HashSet<ApplicationUserContact>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(PhoneMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        public string? Address { get; set; }

        public string Website { get; set; } = null!;

        public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; }
    }
}
