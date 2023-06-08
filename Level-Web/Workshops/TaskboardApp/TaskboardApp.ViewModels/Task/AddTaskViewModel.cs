namespace TaskboardApp.ViewModels.Task
{
    using System.ComponentModel.DataAnnotations;
    using static TaskboardApp.Common.ErrorConstants;
    using static TaskboardApp.Common.DataConstants.TaskConstants;
    using TaskboardApp.Data.Entities;
    using TaskboardApp.ViewModels.Board;

    public class AddTaskViewModel
    {
        public AddTaskViewModel()
        {
            this.Boards = new List<BoardViewModel>();
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
