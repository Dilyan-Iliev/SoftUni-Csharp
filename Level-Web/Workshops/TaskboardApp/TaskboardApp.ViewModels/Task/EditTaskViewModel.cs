namespace TaskboardApp.ViewModels.Task
{
    using static TaskboardApp.Common.ErrorConstants;
    using static TaskboardApp.Common.DataConstants.TaskConstants;
    using System.ComponentModel.DataAnnotations;
    using TaskboardApp.ViewModels.Board;

    public class EditTaskViewModel
    {
        public EditTaskViewModel()
        {
            this.Boards = new HashSet<BoardViewModel>();
        }

        [Required(ErrorMessage = FieldRequired)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength,
            ErrorMessage = FieldLengthError)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = FieldRequired)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,
            ErrorMessage = FieldLengthError)]
        public string Description { get; set; } = null!;

        public int BoardId { get; set; }

        public ICollection<BoardViewModel> Boards { get; set; }
    }
}
