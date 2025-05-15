namespace BookShop
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

            string input = Console.ReadLine();
            string result = GetBooksByAgeRestriction(db, input);
            Console.WriteLine(result);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {

            bool areEquial = Enum.TryParse(command, true, out AgeRestriction ageCommand);


            if (string.IsNullOrEmpty(command) || !areEquial)
            {
                return default;
            }

            var books = context.Books
                .Where(b => b.AgeRestriction==ageCommand)
                .Select(b => b.Title)
                .OrderBy(b=>b)
                .ToArray();

            //StringBuilder sb = new StringBuilder();

            //foreach(var book in books)
            //    sb.AppendLine(book.Title)


            return string.Join(Environment.NewLine, books);
        }
    }
}


