namespace TaskboardApp.ViewModels.Board
{
    using TaskboardApp.ViewModels.Task;

    public class IndexBoardViewModel
    {
        public IndexBoardViewModel()
        {
                this.Tasks = new List<IndexTaskViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<IndexTaskViewModel> Tasks { get; set; }
    }
}
