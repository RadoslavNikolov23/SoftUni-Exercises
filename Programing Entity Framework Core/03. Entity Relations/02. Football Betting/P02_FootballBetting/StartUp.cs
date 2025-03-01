using Microsoft.EntityFrameworkCore;
using P02_FootballBetting.Data;

namespace P02_FootballBetting
{
    public class StartUp
    {
        public static void Main()
        {

            Console.WriteLine("Staring to create the DB - FootballBetting....");

            try
            {
                using FootballBettingContext context = new FootballBettingContext();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Console.WriteLine("The database FootballBettingContext was created!");


            }
            catch (Exception e)
            {
                Console.WriteLine("The database wasn't created, somethind went wrong:");
                Console.WriteLine(e.Message);

            }
        }
    }
}
