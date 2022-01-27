using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                var bookShopContext = new BookShopContext();
                var result = RemoveBooks(bookShopContext);
                Console.WriteLine(result);

                //IncreasePrices(db); - to test Problem 14.Increase Prices 
            }
        }

        // 1. Age Restriction 
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var bookTitles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(t => new
                {
                    t.Title
                })
                .OrderBy(t => t.Title)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var title in bookTitles)
            {
                sb.AppendLine($"{title.Title}");
            }

            return sb.ToString().TrimEnd();
        }

        // 2. Golden Books 
        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenEdition = Enum.Parse<EditionType>("Gold", true);

            var goldenBooksTitles = context.Books
                .Where(b => b.EditionType == goldenEdition && b.Copies < 5000)
                .Select(b => new
                {
                    b.BookId,
                    b.Title
                })
                .OrderBy(b => b.BookId)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var title in goldenBooksTitles)
            {
                sb.AppendLine($"{title.Title}");
            }

            return sb.ToString().TrimEnd();
        }

        // 3. Books by Price 
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var title in books)
            {
                sb.AppendLine($"{title.Title} - ${title.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 4. Not Released In 
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .Select(b => new
                {
                    b.BookId,
                    b.Title
                })
                .OrderBy(b => b.BookId)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var title in books)
            {
                sb.AppendLine($"{title.Title}");
            }

            return sb.ToString().TrimEnd();
        }

        // 5. Book Titles by Category 
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<string> categories = input.ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var books = context.BooksCategories
                .Select(b => new
                {
                    b.Category,
                    b.Book.Title
                })
                .OrderBy(b => b.Title)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                if (categories.Contains(book.Category.Name.ToLower()))
                {
                    sb.AppendLine($"{book.Title}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // 6. Released Before Date 
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .Select(b => new
                {
                    b.ReleaseDate.Value,
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .OrderByDescending(b => b.Value)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 7. Author Search 
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var autors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}"
                })
                .OrderBy(a => a.FullName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var name in autors)
            {
                sb.AppendLine($"{name.FullName}");
            }

            return sb.ToString().TrimEnd();
        }

        // 8. Book Search 
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var titles = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title)
                .ToList();

            var sb = new StringBuilder();

            foreach (var title in titles)
            {
                sb.AppendLine($"{title.Title}");
            }

            return sb.ToString().TrimEnd();
        }

        // 9. Book Search by Author 
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    AuthorFullName = $"{b.Author.FirstName} {b.Author.LastName}"
                })
                .OrderBy(b => b.BookId)
                .ToList();

            var sb = new StringBuilder();

            foreach (var title in books)
            {
                sb.AppendLine($"{title.Title} ({title.AuthorFullName})");
            }

            return sb.ToString().TrimEnd();
        }

        // 10. Count Books 
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToList();

            int result = books.Count;

            return result;
        }

        // 11. Total Book Copies 
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    AuthorFullName = $"{a.FirstName} {a.LastName}",
                    BookCopies = a.Books.Sum(c => c.Copies)
                })
                .OrderByDescending(a => a.BookCopies)
                .ToList();

            var sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.AuthorFullName} - {author.BookCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        // 12. Profit by Category 
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var profitRank = context.Categories
                .Select(b => new
                {
                    CategoryName = b.Name,
                    Profit = b.CategoryBooks.Sum(p => p.Book.Copies * p.Book.Price)
                })
                .OrderByDescending(b => b.Profit)
                .ThenBy(b => b.CategoryName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var category in profitRank)
            {
                sb.AppendLine($"{category.CategoryName} ${category.Profit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 13. Most Recent Books 
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var books = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Books = c.CategoryBooks.Select(b => new
                    {
                        b.Book.Title,
                        b.Book.ReleaseDate.Value
                    })
                        .OrderByDescending(b => b.Value)
                        .Take(3)
                        .ToList()
                })
                .OrderBy(c => c.CategoryName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var category in books)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var title in category.Books)
                {
                    sb.AppendLine($"{title.Title} ({title.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // 14. Increase Prices 
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        // 15. Remove Books 
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToBeRemoved = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.RemoveRange(booksToBeRemoved);

            context.SaveChanges();

            return booksToBeRemoved.Count;
        }
    }
}

