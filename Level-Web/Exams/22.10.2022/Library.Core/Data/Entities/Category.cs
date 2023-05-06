namespace Library.Core.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using static Library.Common.DataConstants.CategoryConstants;

    public class Category
    {
        public Category()
        {
            this.Books = new HashSet<Book>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; }
    }
}
