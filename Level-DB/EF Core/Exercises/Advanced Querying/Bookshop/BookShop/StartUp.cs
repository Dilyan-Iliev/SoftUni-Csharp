namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();

            //Invoke desired method:
        }

        //Task.02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            string[] bookTitles = context
                .Books
                .AsEnumerable()
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        //Task.03
        public static string GetGoldenBooks(BookShopContext context)
        {
            string[] goldenEditionBookTitles = context
                .Books
                .AsEnumerable()
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, goldenEditionBookTitles);
        }

        //Task.04
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Task.05
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            string[] bookTitles = context
                .Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        //Task.06
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            string[] categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            IQueryable<BookCategory> dbBooks = context
                .BooksCategories
                .Include(bc => bc.Category)
                .Include(bc => bc.Book);

            List<BookCategory> books = new List<BookCategory>();

            foreach (var category in categories)
            {
                foreach (var book in dbBooks)
                {
                    if (book.Category.Name.ToLower() == category.ToLower())
                    {
                        books.Add(book);
                    }
                }
            }

            var titles = books
                .OrderBy(b => b.Book.Title)
                .Select(b => b.Book.Title)
                .ToList();

            return string.Join(Environment.NewLine, titles);
        }

        //Task.07
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            var inputStringArray = date.Split("-").Reverse().ToArray();
            var newStringDate = String.Join("-", inputStringArray);
            DateTime formatedDate = DateTime.Parse(newStringDate);

            var books = context
                .Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value < formatedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Task.08
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var authors = context
                .Authors
                .AsEnumerable()
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}"
                })
                .OrderBy(a => a.FullName)
                .ToArray();

            foreach (var author in authors)
            {
                sb.AppendLine(author.FullName);
            }

            return sb.ToString().TrimEnd();
        }

        //Task.09
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string[] bookTitles = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        //Task.10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorName = $"{b.Author.FirstName} {b.Author.LastName}"
                })
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorName})");
            }

            return sb.ToString().TrimEnd();
        }

        //Task.11
        public static int CountBooks(BookShopContext context, int lengthCheck)
         => context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

        //Task.12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var sb = new StringBuilder();

            var bookCopies = context
                .Authors
                .Select(a => new
                {
                    AuthorName = $"{a.FirstName} {a.LastName}",
                    CopiesCount = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.CopiesCount)
                .ToArray();

            foreach (var bookCopy in bookCopies)
            {
                sb.AppendLine($"{bookCopy.AuthorName} - {bookCopy.CopiesCount}");
            }

            return sb.ToString().TrimEnd();
        }

        //Task.13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();

            var result = context
                .Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Profit = c.CategoryBooks
                        .Select(cb => new
                        {
                            Result = cb.Book.Copies * cb.Book.Price
                        })
                        .Sum(c => c.Result)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.CategoryName)
                .ToArray();

            foreach (var item in result)
            {
                sb.AppendLine($"{item.CategoryName} ${item.Profit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Task.14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var booksByCategories = context
                .Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Books = c.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate)
                        .Take(3)
                        .Select(cb => new
                        {
                            BookTitle = cb.Book.Title,
                            ReleaseDate = cb.Book.ReleaseDate.Value.Year
                        })
                        .ToArray()
                })
                .OrderBy(c => c.CategoryName)
                .ToArray();

            foreach (var category in booksByCategories)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.ReleaseDate})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Task.15
        public static void IncreasePrices(BookShopContext context)
        {
            var booksBefore2010 = context
                .Books
                .Where(b => b.ReleaseDate.HasValue
                && b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var book in booksBefore2010)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //Task.16
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.Books
                .RemoveRange(books);

            context.SaveChanges();

            return books.Count();
        }
    }
}


