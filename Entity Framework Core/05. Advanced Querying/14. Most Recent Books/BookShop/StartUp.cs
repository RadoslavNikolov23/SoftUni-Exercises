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

            //string input = Console.ReadLine();
            string result = GetMostRecentBooks(db);
            Console.WriteLine(result);
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {

            // string[] dateValues = date.Split('-', StringSplitOptions.RemoveEmptyEntries);


            var catrgories = context.Categories
                .Include(c => c.CategoryBooks)
                .ThenInclude(cb => cb.Book)
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Books = c.CategoryBooks
                                .OrderByDescending(cb => cb.Book.ReleaseDate)
                                .Select(cb => new
                                {
                                    cb.Book.Title,
                                    cb.Book.ReleaseDate
                                })
                                .Take(3)
                                .ToArray()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var category in catrgories)
            {
                sb.AppendLine($"--{category.CategoryName}");


                foreach (var books in category.Books)
                {
                    sb.AppendLine($"{books.Title} ({books.ReleaseDate?.Date.Year.ToString() ?? "Unknown Year"})");
                }
            }


            return sb.ToString().Trim();
            //return String.Join(Environment.NewLine,books);
        }
    }
}


