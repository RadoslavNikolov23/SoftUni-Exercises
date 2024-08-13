using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string phoneNumbersInput = Console.ReadLine();
            string pattern = @"((\+359)\b [2] (\d{3})\b (\d{4})\b|(\+359)\b-[2]-(\d{3})\b-(\d{4}))\b";

            
            var mathcesPhoneList = Regex.Matches(phoneNumbersInput, pattern);

            Console.WriteLine(string.Join(", ", mathcesPhoneList));
           

        }
    }
}
