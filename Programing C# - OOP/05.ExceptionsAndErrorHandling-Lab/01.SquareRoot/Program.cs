namespace _01.SquareRoot
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());

                double squareRoot = Math.Sqrt(number);
                double nan = double.NaN;

                if (double.IsNaN(squareRoot))
                    throw new ArgumentException("Invalid number.");

                 Console.WriteLine(squareRoot);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);


            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }


        }
    }
}
