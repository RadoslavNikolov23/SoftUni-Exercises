using System.Text.RegularExpressions;

namespace _02.MessageTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int numberOfStrings = int.Parse(Console.ReadLine());
            string input;
            string pattern = @"(\!)(?<PartOne>[A-Z{1}][a-z]{2,})\1(?<PartTwo>\:)(\[(?<Translate>[A-Za-z]{8,})\])";

            for (int i = 0; i < numberOfStrings; i++)
            {
                input = Console.ReadLine();

                MatchCollection messages = Regex.Matches(input, pattern);

                if (messages.Count > 0)
                {
                    foreach (Match message in Regex.Matches(input, pattern))
                    {
                        string messageToTranslate = message.Groups["Translate"].ToString();
                        List<int> messageToChar= new List<int>();
                        
                        for (int j = 0; j < messageToTranslate.Length; j++)
                        {
                          messageToChar.Add(messageToTranslate[j]);
                           
                        }

                        Console.WriteLine($"{message.Groups["PartOne"]}{message.Groups["PartTwo"]} {(string.Join(" ",messageToChar))}");
                    }
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
               
               

            }
        }
    }
}
