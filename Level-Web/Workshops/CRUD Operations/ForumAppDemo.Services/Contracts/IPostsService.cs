namespace ForumAppDemo.Services.Contracts
{
    using ForumAppDemo.Infrastructure.Data.Entities;
    using ForumAppDemo.Models;
    using ForumAppDemo.Services.DTOs;

    public interface IPostsService
    {
        Task<IEnumerable<PostViewModel>> GetAll();

        Task AddPost(AddPostModel model);

        Task DeletePost(int id);

        Task<Post> FindPost(int id);

        Task EditPost(int id, PostViewModel model);
    }
}
