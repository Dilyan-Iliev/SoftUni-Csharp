namespace ForumApp.Services.Contracts
{
    using ForumApp.Infrastructure.Data.Entities;
    using ForumApp.Services.DTOs;

    public interface IPostService
    {
        Task<IEnumerable<IndexPostDto>> AllAsync();

        Task AddAsync(AddPostDto model);

        Task<Post> FindByIdAsync(int id);

        Task EditAsync(int id, EditPostDto model);

        Task DeleteAsync(int id);
    }
}
