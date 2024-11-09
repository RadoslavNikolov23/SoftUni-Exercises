using System.Xml.Linq;

namespace _04.SumOfIntegers
{
    public class Program
    {
        static void Main()
        {
            string[] diffrentTypes = Console.ReadLine().Split(" ");

            int sumAllValidNumbers = 0;

            for (int i = 0; i < diffrentTypes.Length; i++)
            {
                try
                {
                    int number = int.Parse(diffrentTypes[i]);
                    sumAllValidNumbers += number;
                }
                catch(FormatException ex)
                {
                    Console.WriteLine($"The element '{diffrentTypes[i]}' is in wrong format!");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"The element '{diffrentTypes[i]}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{diffrentTypes[i]}' processed - current sum: {sumAllValidNumbers}");
                }
            }
            Console.WriteLine($"The total sum of all integers is: {sumAllValidNumbers}");

        }
    }
}
