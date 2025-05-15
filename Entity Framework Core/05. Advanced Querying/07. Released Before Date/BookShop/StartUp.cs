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
            DbInitializer.ResetDatabase(db);

            string input = Console.ReadLine();
            string result = GetBooksReleasedBefore(db, input);
            Console.WriteLine(result);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {

            string[] dateValues = date.Split('-', StringSplitOptions.RemoveEmptyEntries);

            if (dateValues.Count() != 3) return default;

            DateTime inputDate = new DateTime(int.Parse(dateValues[2]), int.Parse(dateValues[1]), int.Parse(dateValues[0]));


            var books = context.Books
                .Where(b => b.ReleaseDate<inputDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType.ToString()} - ${book.Price.ToString("F2")}");
            }


            return sb.ToString().Trim();
            //return String.Join(Environment.NewLine,books);
        }
    }
}


