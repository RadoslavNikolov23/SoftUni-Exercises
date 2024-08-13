using System.Text.RegularExpressions;

namespace _02.Problem2_DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([\=\/])(?<Citys>[A-Z][A-Za-z]{2,})\1";
            string input = Console.ReadLine();

            List<string> citiesList= new List<string>();

            foreach (Match matchCitys in Regex.Matches(input, pattern))
            {
                citiesList.Add(matchCitys.Groups["Citys"].Value);
            }

            int travelPoins = 0;

            citiesList.ForEach(c=>travelPoins+=c.Length);

            Console.WriteLine($"Destinations: {string.Join(", ",citiesList)}");
            Console.WriteLine($"Travel Points: {travelPoins}");
        }
    }
}
