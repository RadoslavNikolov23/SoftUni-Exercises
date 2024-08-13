using System.Text.RegularExpressions;

namespace _02.Problem2_MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string patter = @"([\@\#])(?<FirstWord>[A-Za-z]{3,})\1{2}(?<SecondWord>[A-Za-z]{3,})\1";

            MatchCollection match = Regex.Matches(input, patter);

            List<string> wordMirrorList= new List<string>();

            foreach (Match mirrorWord in match)
            {
                if (mirrorWord.Groups["FirstWord"].Length == mirrorWord.Groups["SecondWord"].Length)
                {
                    string secondWord = new string(mirrorWord.Groups["SecondWord"].Value.Reverse().ToArray());
                    if (mirrorWord.Groups["FirstWord"].Value == secondWord)
                    {
                        wordMirrorList.Add($"{mirrorWord.Groups["FirstWord"].Value} <=> {mirrorWord.Groups["SecondWord"].Value}");
                    }
                }
             
            }

            if (match.Count > 0)
            {
                Console.WriteLine($"{match.Count} word pairs found!");

            }
            else
            {
                Console.WriteLine($"No word pairs found!");

            }

            if (wordMirrorList.Count > 0)
            {
                Console.WriteLine($"The mirror words are:");
                Console.WriteLine($"{string.Join(", ", wordMirrorList)}");
            }
            else
            {
                Console.WriteLine($"No mirror words!");
            }


        }
    }
}
