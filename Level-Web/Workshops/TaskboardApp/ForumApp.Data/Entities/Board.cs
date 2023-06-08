namespace TaskboardApp.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using static TaskboardApp.Common.DataConstants.BoardConstants;
    public class Board
    {
        public Board()
        {
            this.Tasks = new HashSet<TaskEntity>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<TaskEntity> Tasks { get; set; }
    }
}
