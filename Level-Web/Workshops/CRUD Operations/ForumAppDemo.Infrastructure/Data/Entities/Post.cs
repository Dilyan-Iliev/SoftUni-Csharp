namespace ForumAppDemo.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        public int Id { get; init; }

        [Required]
        [StringLength(DataConstants.PostTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.PostContentMaxLength)]
        public string Content { get; set; } = null!;
    }
}
