namespace ForumAppDemo.Services.DTOs
{
    using ForumAppDemo.Infrastructure.Data;
    using System.ComponentModel.DataAnnotations;

    public class AddPostModel
    {
        [Required(ErrorMessage = "Заглавието е задължително")]
        [StringLength(DataConstants.PostTitleMaxLength, MinimumLength = DataConstants.PostTitleMinLength,
            ErrorMessage = "Минимум 10 и максимум 50 знака")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Съдържанието е задължително")]
        [StringLength(DataConstants.PostContentMaxLength, MinimumLength = DataConstants.PostContentMinlength,
            ErrorMessage = "Минимум 30 и максимум 1500 знака")]
        public string Content { get; set; }
    }
}
