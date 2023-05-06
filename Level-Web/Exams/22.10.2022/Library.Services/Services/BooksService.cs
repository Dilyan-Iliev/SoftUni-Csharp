namespace Library.Services.Services
{
    using Library.Core.Data;
    using Library.Core.Data.Entities;
    using Library.Services.Contracts;
    using Library.Services.DTOs;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BooksService
        : IBooksService
    {
        private readonly LibraryDbContext context;

        public BooksService(LibraryDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<AllBooksDto>> GetAllAsync()
         => await this.context
                .Books
                .Select(book => new AllBooksDto()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    ImageUrl = book.ImageUrl,
                    Rating = book.Rating,
                    Category = book.Category.Name
                })
                .ToListAsync();

        public async Task<ICollection<Category>> GetCategoriesAsync()
        => await this.context.Categories
            .ToListAsync();

        public async Task AddNewAsync(AddBookDto addBookDto)
        {
            Book book = new Book
            {
                Title = addBookDto.Title,
                Author = addBookDto.Author,
                Description = addBookDto.Description,
                Rating = addBookDto.Rating,
                ImageUrl = addBookDto.ImageUrl,
                CategoryId = addBookDto.CategoryId,
            };

            await this.context.Books
                .AddAsync(book);
            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<MyBooksDto>> GetMyBooksAsync(string userId)
        {
            ApplicationUser user = await GetUserById(userId);

            return user
                .ApplicationUsersBooks
                .Select(u => new MyBooksDto()
                {
                    Id = u.Book.Id,
                    Title = u.Book.Title,
                    Description = u.Book.Description,
                    Author = u.Book.Author,
                    ImageUrl = u.Book.ImageUrl,
                    Category = u.Book.Category.Name
                })
                .ToList();
        }
        public async Task AddToCollection(string userId, int bookId)
        {
            ApplicationUser user = await GetUserById(userId);

            if (!user.ApplicationUsersBooks.Any(u => u.BookId == bookId))
            {
                Book book = await context
                    .Books
                    .FirstOrDefaultAsync(b => b.Id == bookId)
                    ?? throw new ArgumentNullException("Invalid book ID");

                var appUserBook = new ApplicationUserBook()
                {
                    ApplicationUserId = user.Id,
                    BookId = book.Id
                };

                user.ApplicationUsersBooks.Add(appUserBook);
                await context.SaveChangesAsync();
            }
        }
        public async Task RemoveFromCollection(string userId, int bookId)
        {
            ApplicationUser user = await GetUserById(userId);

            var book = await this.context
                .ApplicationUsersBooks
                .FirstOrDefaultAsync(b => b.Book.Id == bookId)
                ?? throw new ArgumentNullException("Invalid book ID");

            if (book != null)
            {
                user.ApplicationUsersBooks.Remove(book);
                await context.SaveChangesAsync();
            }
        }

        private async Task<ApplicationUser> GetUserById(string userId)
            => await this.context.Users
                            .Where(u => u.Id == userId)
                            .Include(u => u.ApplicationUsersBooks)
                            .ThenInclude(u => u.Book)
                                .ThenInclude(u => u.Category)
                            .FirstOrDefaultAsync()
                            ?? throw new ArgumentNullException("Invalid user ID");

    }
}
