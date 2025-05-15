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
            string result = GetBookTitlesContaining(db, input);
            Console.WriteLine(result);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {

            // string[] dateValues = date.Split('-', StringSplitOptions.RemoveEmptyEntries);


            var books = context.Books
                .Select(b => b.Title)
                .Where(b => b.ToLower().Contains(input.ToLower()))
                .OrderBy(b=>b)
                .ToArray();



            //    .Where(a => a.FirstName.EndsWith(input))
            //    .Select(a => new
            //    {
            //        a.FirstName,
            //        a.LastName
            //    })
            //    .ToArray();

            //authors= authors.OrderBy(a => a.FirstName)
            //                .ThenBy(a=>a.LastName)
            //                .ToArray();

            //StringBuilder sb = new StringBuilder();

            //foreach (var author in authors)
            //{
            //    sb.AppendLine($"{author.FirstName} {author.LastName}");
            //}


            //return sb.ToString().Trim();
             return String.Join(Environment.NewLine,books);
        }
    }
}


