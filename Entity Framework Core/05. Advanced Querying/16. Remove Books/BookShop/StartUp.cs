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

            int result = RemoveBooks(db);
            Console.WriteLine(result);
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200);

            int result = books.Count();
            context.RemoveRange(books);

            context.SaveChanges();
            return result;
        }
    }
}


