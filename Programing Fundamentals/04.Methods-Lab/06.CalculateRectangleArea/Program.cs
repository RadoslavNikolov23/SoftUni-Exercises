namespace _06.CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());

            Console.WriteLine(AreaOfRectangle(numberOne, numberTwo));
          

            static int AreaOfRectangle(int a, int b)
            {
                return a * b;
            }

        }
    }
}
