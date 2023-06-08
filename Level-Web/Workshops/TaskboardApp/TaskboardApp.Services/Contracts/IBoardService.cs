namespace TaskboardApp.Services.Contracts
{
    using System.Threading.Tasks;
    using TaskboardApp.Data.Entities;
    using TaskboardApp.ViewModels.Board;

    public interface IBoardService
    {
        Task<ICollection<IndexBoardViewModel>> GetAllAsync();

        Task<ICollection<BoardViewModel>> GetBoardsAsync();
    }
}
