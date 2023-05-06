namespace Library.Core.Data.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationUserBook
    {
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }

        public Book Book { get; set; }
    }
}
