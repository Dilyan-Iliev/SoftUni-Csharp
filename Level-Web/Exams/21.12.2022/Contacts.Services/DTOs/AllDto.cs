namespace Contacts.Services.DTOs
{
    public class AllDto
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Website { get; set; } = null!;
    }
}
