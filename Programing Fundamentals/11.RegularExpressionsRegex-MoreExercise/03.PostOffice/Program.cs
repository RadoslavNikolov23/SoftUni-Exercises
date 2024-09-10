using System.Text.RegularExpressions;

namespace _03.PostOffice
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split("|");

            string pattern1 = @"([\#|\$|\%|\*|\&])([A-Z]+)([\#|\$|\%|\*|\&])";
            List<char> symbolsList = new List<char>();

            string pattern2 = @"([\d]{2})(:)([\d]{2})";
            string messageTwo = String.Empty;
            Dictionary<int, int> dictSymbLeght = new Dictionary<int, int>();

            string pattern3 = @"\b([A-Z]{1}\S+)|\s";
            List<string> wordList = new List<string>();


            foreach (Match match in Regex.Matches(input[0], pattern1))
            {
                if (match.Groups[1].Value == match.Groups[3].Value)
                {
                    for (int i = 0; i < match.Groups[2].Value.Length; i++)
                    {
                        char temp = match.Groups[2].Value[i];
                        symbolsList.Add(temp);
                    }
                }
            }

            foreach (Match match in Regex.Matches(input[1], pattern2))
            {
                if (dictSymbLeght.ContainsKey(int.Parse(match.Groups[1].Value)))
                {
                    continue;
                }
                else
                {

                dictSymbLeght.Add(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[3].Value));
                }
            }

            foreach (Match match in Regex.Matches(input[2], pattern3))
            {
                if (match.ToString() == " ")
                {
                    continue;
                }
                else
                {
                    wordList.Add(match.Groups[0].Value);
                }
            }

            List<string> finalMessage = new List<string>();
            for (int i = 0; i < symbolsList.Count; i++)
            {
                char tempSym = symbolsList[i];
                int leghtWord = 0;

                foreach (var symLeg in dictSymbLeght)
                {
                    if ((int)tempSym == symLeg.Key)
                    {
                        leghtWord = symLeg.Value + 1;
                        break;
                    }
                }

                foreach (var word in wordList)
                {
                    if (word[0] == tempSym && word.Length == leghtWord)
                    {
                        finalMessage.Add((word));
                        break;
                    }
                }

            }

            foreach (var wordFinal in finalMessage)
            {
                Console.WriteLine(wordFinal);
            }

        }
    }
}
