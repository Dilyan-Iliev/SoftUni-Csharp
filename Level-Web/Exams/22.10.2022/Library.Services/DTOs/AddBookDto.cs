namespace Library.Services.DTOs
{
    using Library.Core.Data.Entities;
    using System.ComponentModel.DataAnnotations;
    using static Library.Common.ErrorConstants;
    using static Library.Common.DataConstants.BookConstants;

    public class AddBookDto
    {
        public AddBookDto()
        {
            this.Categories = new HashSet<Category>();
        }

        [Required(ErrorMessage = FieldRequired)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength,
            ErrorMessage = FieldCharactersLength)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = FieldRequired)]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength,
            ErrorMessage = FieldCharactersLength)]
        public string Author { get; set; } = null!;

        [Required(ErrorMessage = FieldRequired)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,
            ErrorMessage = FieldCharactersLength)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = FieldRequired)]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = FieldRequired)]
        [Range(typeof(decimal), "0.00", "10.00",
            ErrorMessage = "Стойността трябва да е между 0 и 10")]
        public decimal Rating { get; set; }

        public int CategoryId { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
