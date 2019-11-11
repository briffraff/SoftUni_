using System;
using System.Globalization;
using System.Linq;
using System.Text;
using BookShop.Models.Enums;

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
                var inputCommand = (Console.ReadLine()); // 1
               // var result = GetBooksByAgeRestriction(db, inputCommand); // 1
                var result = GetBooksByAuthor(db,inputCommand);
                Console.WriteLine(result);
         
            }
        }

        //9
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksWithAuthor = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new { b.Title, b.Author.FirstName, b.Author.LastName })
                .ToList();

            return String.Join(Environment.NewLine, booksWithAuthor.Select(b => $"{b.Title} ({b.FirstName} {b.LastName})"));
        }
        //8
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var booksTitles = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, booksTitles);
        }
        //7
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorNames = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .OrderBy(a => a)
                .ToList();

            return String.Join(Environment.NewLine, authorNames);
        }
        //5
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower()).ToArray();

            var booksTitles = context.Books
                .Where(b => b.BookCategories
                    .Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, booksTitles);
        }

        //4
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var booksTitles = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, booksTitles);
        }

        //6
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime convertedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context.Books
                .Where(b => b.ReleaseDate < convertedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}")
                .ToList();

            var result = String.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            //Return in a single string all titles and prices of books with price higher than 40,
            //each on a new row in the format given below. Order them by price descending.O Pioneers! - $49.90
            var titleAndPrices = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var titleAndPrice in titleAndPrices)
            {
                sb.AppendLine($"{titleAndPrice.Title} - ${titleAndPrice.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenEdition = EditionType.Gold;

            var goldenEditionTitles = context.Books
                .Where(b => b.EditionType == goldenEdition)
                .Where(b => b.Copies < 5000)
                .Select(b => new
                {
                    Title = b.Title,
                    BookId = b.BookId
                })
                .OrderBy(b => b.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var goldenEditionTitle in goldenEditionTitles)
            {
                sb.AppendLine($"{goldenEditionTitle.Title}");
            }
     
            return sb.ToString().TrimEnd();

        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var booksTitle = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList();


            var result = string.Join(Environment.NewLine, booksTitle);

            return result;
        }
    }
}
