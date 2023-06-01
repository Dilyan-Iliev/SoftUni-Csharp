namespace ForumApp.Services.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using static ForumApp.Common.DataConstants.PostConstants;
    using static ForumApp.Common.ErrorConstants;

    public class IndexPostDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;
    }
}
