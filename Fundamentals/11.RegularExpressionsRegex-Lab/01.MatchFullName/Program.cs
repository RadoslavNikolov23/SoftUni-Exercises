using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b[A-Z{1}][a-z]+ [A-Z{1}][a-z]+";

            foreach (Match name in Regex.Matches(input, pattern))
            {
                Console.Write($"{name.Value} ");
            }

        }
    }
}
