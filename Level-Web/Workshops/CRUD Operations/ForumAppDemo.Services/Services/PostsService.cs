namespace ForumAppDemo.Services.Services
{
    using ForumAppDemo.Infrastructure.Data;
    using ForumAppDemo.Infrastructure.Data.Entities;
    using ForumAppDemo.Models;
    using ForumAppDemo.Services.Contracts;
    using ForumAppDemo.Services.DTOs;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class PostsService : IPostsService
    {
        private readonly ApplicationDbContext context;

        public PostsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddPost(AddPostModel model)
        {
            var post = new Post
            {
                Title = model.Title,
                Content = model.Content
            };

            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
        }

        public async Task DeletePost(int id)
        {
            var post = await context
                .Posts
                .FirstOrDefaultAsync(p => p.Id == id);

            if (post != null)
            {
                context.Posts
                    .Remove(post); // TODO: add bool flag for delete instead of hard delete
                await context.SaveChangesAsync();
            }
        }

        public async Task EditPost(int id, PostViewModel model)
        {
            var postForEdit = await FindPost(id);
            postForEdit.Content = model.Content;
            postForEdit.Title = model.Title;

            await context.SaveChangesAsync();
        }

        public async Task<Post> FindPost(int id)
        {
            var postForEdit = await context
                .Posts
                .FirstOrDefaultAsync(p => p.Id == id);

            return postForEdit;
        }

        public async Task<IEnumerable<PostViewModel>> GetAll()
        {
            var posts = await context
                .Posts
                .Select(p => new PostViewModel
                {
                    Id = p.Id,
                    Content = p.Content,
                    Title = p.Title,
                })
                .ToListAsync();

            return posts;
        }
    }
}
