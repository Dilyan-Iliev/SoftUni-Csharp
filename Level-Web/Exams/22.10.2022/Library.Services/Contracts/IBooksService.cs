namespace Library.Services.Contracts
{
    using Library.Core.Data.Entities;
    using Library.Services.DTOs;

    public interface IBooksService
    {
        Task<ICollection<AllBooksDto>> GetAllAsync();

        Task AddNewAsync(AddBookDto addBookDto);

        Task<ICollection<Category>> GetCategoriesAsync();

        Task<ICollection<MyBooksDto>> GetMyBooksAsync(string userId);

        Task AddToCollection(string userId, int bookId);

        Task RemoveFromCollection(string userId, int bookId);
    }
}
