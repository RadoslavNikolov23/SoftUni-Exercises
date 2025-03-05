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

            //string input = Console.ReadLine();
            string result = GetGoldenBooks(db);
            Console.WriteLine(result);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            EditionType goldenType = EditionType.Gold;

            string[] books = context.Books
                .Where(b => b.EditionType == goldenType
                        && b.Copies < 5000)
                .OrderBy(b=>b.BookId)
                .Select(b => b.Title)
                .ToArray();


            return string.Join(Environment.NewLine, books);
        }
    }
}


