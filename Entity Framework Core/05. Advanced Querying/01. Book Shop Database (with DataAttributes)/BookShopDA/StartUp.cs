namespace BookShopDA
{
    using BookShopDA.Data;

    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine("Starting do create BookShoop with DataAttributes DB.....");

            try
            {
                using BookShopDbContex contex = new BookShopDbContex();
                contex.Database.EnsureDeleted();
                contex.Database.EnsureCreated();
                Console.WriteLine("BookShop with DataAttributes DataBase create successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("DataBase wasn't create, something went wrong:!");
                Console.WriteLine(e.Message);
            }
        }
    }
}
