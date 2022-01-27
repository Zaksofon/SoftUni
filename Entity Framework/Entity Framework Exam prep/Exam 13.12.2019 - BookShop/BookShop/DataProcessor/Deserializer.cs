using BookShop.Data.Models;
using BookShop.Data.Models.Enums;
using BookShop.DataProcessor.ImportDto;

namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var bookXmlInputAsString = XmlConverter.Deserializer<BookImportDto>(xmlString, "Books");

            var sb = new StringBuilder();

            foreach (var bookXml in bookXmlInputAsString)
            {
                if (!IsValid(bookXml))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var book = new Book()
                {
                    Name = bookXml.Name,
                    Genre = (Genre)bookXml.Genre,
                    Price = decimal.Parse(bookXml.Price.ToString("F2")),
                    Pages = bookXml.Pages,
                    PublishedOn = DateTime.ParseExact(bookXml.PublishedOn, "MM/dd/yyyy", CultureInfo.InstalledUICulture)
                };
                context.Books.Add(book);
                context.SaveChanges();
                sb.AppendLine($"Successfully imported book {bookXml.Name} for {book.Price}.");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authorImportJsonAsString = JsonConvert.DeserializeObject<IEnumerable<AuthorsImportDto>>(jsonString);

            var sb = new StringBuilder();

            List<Author> authorsList = new List<Author>();

            foreach (var authorJson in authorImportJsonAsString)
            {
                if (!IsValid(authorJson))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool doesEmailExists = authorsList
                    .FirstOrDefault(x => x.Email == authorJson.Email) != null;

                if (doesEmailExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author
                {
                    FirstName = authorJson.FirstName,
                    LastName = authorJson.LastName,
                    Email = authorJson.Email,
                    Phone = authorJson.Phone
                };

                var uniqueBookIds = authorJson.Books.Distinct();

                foreach (var bookJson in uniqueBookIds)
                {
                    var book = context.Books.Find(bookJson.Id);

                    if (book == null)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook
                    {
                        Author = author,
                        Book = book
                    });
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                authorsList.Add(author);
                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, (author.FirstName + " " + author.LastName), author.AuthorsBooks.Count));
            }

            context.Authors.AddRange(authorsList);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}