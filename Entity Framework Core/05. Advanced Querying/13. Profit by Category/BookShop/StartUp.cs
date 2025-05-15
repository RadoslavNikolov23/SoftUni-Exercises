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
            string result = GetTotalProfitByCategory(db);
            Console.WriteLine(result);
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {

            // string[] dateValues = date.Split('-', StringSplitOptions.RemoveEmptyEntries);


            var catrgories = context.Categories
                .Include(c => c.CategoryBooks)
                .ThenInclude(cb => cb.Book)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalProfit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.CategoryName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var category in catrgories)
            {
                sb.AppendLine($"{category.CategoryName} ${category.TotalProfit.ToString("f2")}");
            }


            return sb.ToString().Trim();
            //return String.Join(Environment.NewLine,books);
        }
    }
}


