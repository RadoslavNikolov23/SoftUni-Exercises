using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Staring to create the DB - StudentSystem....");

            try
            {
                using StudentSystemContext context = new StudentSystemContext();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Console.WriteLine("The database StudentSystem was created!");


            }
            catch (Exception e)
            {
                Console.WriteLine("The database wasn't created, somethind went wrong:");
                Console.WriteLine(e.Message);

            }
        }
    }
    
}
