namespace ForumApp.Infrastructure.Data.Entities
{
    public class PageVisit
    {
        public int Id { get; set; }

        public string Url { get; set; } = null!;

        public int VisitsCount { get; set; }

        public string? VisitCookie { get; set; }
    }
}
