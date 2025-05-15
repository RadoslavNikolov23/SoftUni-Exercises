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
            string result = CountCopiesByAuthor(db);
            Console.WriteLine(result);
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {

            // string[] dateValues = date.Split('-', StringSplitOptions.RemoveEmptyEntries);


            var authors = context.Authors
                .Include(a => a.Books)
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    TotalCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.TotalCopies)
                .ToArray();


            //authors= authors.OrderBy(a => a.FirstName)
            //                .ThenBy(a=>a.LastName)
            //                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName} - {author.TotalCopies}");
            }


            return sb.ToString().Trim();
            //return String.Join(Environment.NewLine,books);
        }
    }
}


