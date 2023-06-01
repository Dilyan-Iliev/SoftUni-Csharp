namespace ForumApp.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using static ForumApp.Common.DataConstants.PostConstants;

    public class Post
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
