namespace ForumApp.Services.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using static ForumApp.Common.DataConstants.PostConstants;
    using static ForumApp.Common.ErrorConstants;

    public class AddPostDto
    {
        [Required(ErrorMessage = RequiredField)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength,
            ErrorMessage = FieldLength)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength,
            ErrorMessage = FieldLength)]
        public string Content { get; set; } = null!;
    }
}
