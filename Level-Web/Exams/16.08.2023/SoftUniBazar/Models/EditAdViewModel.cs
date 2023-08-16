namespace SoftUniBazar.Models
{
    using System.ComponentModel.DataAnnotations;

    public class EditAdViewModel
    {
        public EditAdViewModel()
        {
            this.Categories = new List<SelectCategoryViewModel>();
        }

        [Required(ErrorMessage = "The field is required")]
        [StringLength(25, MinimumLength = 5,
            ErrorMessage = "The field must be between 5 and 25 symbols")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "The field is required")]
        [StringLength(250, MinimumLength = 15,
            ErrorMessage = "The field must be between 15 and 250 symbols")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "The field is required")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = "The field is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectCategoryViewModel> Categories { get; set; }
    }
}
