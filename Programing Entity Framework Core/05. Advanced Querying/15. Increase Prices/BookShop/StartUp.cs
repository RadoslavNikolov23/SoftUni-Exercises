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
            //string result = GetMostRecentBooks(db);
            IncreasePrices(db);
           // Console.WriteLine(result);
        }

        public static void IncreasePrices(BookShopContext context)
        {

            // string[] dateValues = date.Split('-', StringSplitOptions.RemoveEmptyEntries);


            var books = context.Books
                .Where(b=>b.ReleaseDate.HasValue &&
                          b.ReleaseDate.Value.Year<2010)
                .ToArray();



            foreach(var book in books)
            {
               // Console.WriteLine(book.Price);
                book.Price += 5;
               // Console.WriteLine("----------");
               // Console.WriteLine(book.Price);
                //Console.WriteLine();
            }

            context.SaveChanges();
            //StringBuilder sb = new StringBuilder();

            //foreach (var category in catrgories)
            //{
            //    sb.AppendLine($"--{category.CategoryName}");


            //    foreach (var books in category.Books)
            //    {
            //        sb.AppendLine($"{books.Title} ({books.ReleaseDate?.Date.Year.ToString() ?? "Unknown Year"})");
            //    }
            //}


           // return sb.ToString().Trim();
            //return String.Join(Environment.NewLine,books);
        }
    }
}


