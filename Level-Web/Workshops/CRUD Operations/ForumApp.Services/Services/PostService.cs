namespace ForumApp.Services.Services
{
    using ForumApp.Infrastructure.Data.Common;
    using ForumApp.Infrastructure.Data.Entities;
    using ForumApp.Services.Contracts;
    using ForumApp.Services.DTOs;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PostService
        : IPostService
    {
        private readonly IRepository repo;

        public PostService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task AddAsync(AddPostDto model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Content = model.Content
            };

            await this.repo.AddAsync<Post>(post);
            await this.repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<IndexPostDto>> AllAsync()
        {
            return await repo.AllReadonly<Post>()
                .Where(p => !p.IsDeleted)
                .Select(p => new IndexPostDto()
                {
                    Id = p.Id,
                    Content = p.Content,
                    Title = p.Title,
                })
                .ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var post = await this.repo
                .All<Post>()
                .FirstAsync(p => p.Id == id);
            post.IsDeleted = true;
            await this.repo.SaveChangesAsync();
        }

        public async Task EditAsync(int id, EditPostDto model)
        {
            var post = await FindByIdAsync(id);

            post.Title = model.Title;
            post.Content = model.Content;

            await this.repo.SaveChangesAsync();
        }

        public async Task<Post> FindByIdAsync(int id)
        {
            return await this.repo
                .All<Post>()
                .FirstAsync(p => p.Id == id);
        }
    }
}
