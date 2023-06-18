namespace Homies.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static Homies.Common.DataConstants.EventConstants;
    using static Homies.Common.ErrorConstants;

    public class EditEventViewModel
    {
        public EditEventViewModel()
        {
            this.Types = new List<TypeViewModel>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength,
            ErrorMessage = FieldLength)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,
            ErrorMessage = FieldLength)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        public int TypeId { get; set; }

        public ICollection<TypeViewModel> Types { get; set; }
    }
}
