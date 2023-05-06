namespace Library.Core.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Library.Common.DataConstants.BookConstants;

    public class Book
    {
        public Book()
        {
            this.ApplicationUsersBooks = new HashSet<ApplicationUserBook>();
        }


        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(AuthorMaxLength)]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public decimal Rating { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<ApplicationUserBook> ApplicationUsersBooks { get; set; }
    }
}
