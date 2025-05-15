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
            string result = GetBooksByCategory(db, input);
            Console.WriteLine(result);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {

            string[] bookCategories = input.Split(' ',StringSplitOptions.RemoveEmptyEntries)
                                    .Select(bc=>bc.ToLower()).ToArray();


            var books = context.Books
                .Include(b=>b.BookCategories)
                .ThenInclude(bc=>bc.Category)
                .Where(b => b.BookCategories.Any(bc=>bookCategories.Contains(bc.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            //StringBuilder sb = new StringBuilder();

            //foreach(var book in books)
            //{
            //    sb.AppendLine($"{book.Title} - ${book.Price.ToString("F2")}");
            //}



            return String.Join(Environment.NewLine,books);
        }
    }
}


