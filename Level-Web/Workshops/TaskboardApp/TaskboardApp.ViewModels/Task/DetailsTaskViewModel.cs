namespace TaskboardApp.ViewModels.Task
{
    public class DetailsTaskViewModel : IndexTaskViewModel
    {
        public string CreatedOn { get; set; } = null!;

        public string Board { get; set; } = null!;
    }
}
