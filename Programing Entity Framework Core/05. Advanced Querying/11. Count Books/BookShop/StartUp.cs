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
            int input = int.Parse(Console.ReadLine());
            int result = CountBooks(db, input);
            Console.WriteLine(result);
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {

            // string[] dateValues = date.Split('-', StringSplitOptions.RemoveEmptyEntries);


            var books = context.Books
                .Where(b=>b.Title.Length>lengthCheck)
                .ToArray();

            return books.Length;
            //authors= authors.OrderBy(a => a.FirstName)
            //                .ThenBy(a=>a.LastName)
            //                .ToArray();

            //StringBuilder sb = new StringBuilder();

            //foreach (var book in books)
            //{
            //    sb.AppendLine($"{book.Title} ({book.AuthorFirstName} {book.AuthorLastName})");
            //}


            //return sb.ToString().Trim();
            //return String.Join(Environment.NewLine,books);
        }
    }
}


