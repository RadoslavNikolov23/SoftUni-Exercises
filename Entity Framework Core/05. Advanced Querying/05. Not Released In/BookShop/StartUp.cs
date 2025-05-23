﻿namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            int year = int.Parse(Console.ReadLine());
            string result = GetBooksNotReleasedIn(db,year);
            Console.WriteLine(result);
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
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


