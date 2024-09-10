using System.Text.RegularExpressions;

namespace _04.SantasSecretHelper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            string input;
            List<string> goodKidList= new List<string>();

            string pattern = @"([\@](?<Name>[A-Za-z]+)[^\@\-\!\:\>]*\!(?<Behavior>[G|N])\!)";

            while ((input = Console.ReadLine()) != "end")
            {
                string tempST=String.Empty;
                for (int i = 0; i < input.Length; i++)
                {
                    char temp= (char)(input[i]-key);
                    tempST += temp;
                }

                foreach (Match match in Regex.Matches(tempST, pattern))
                {
                    if (match.Groups["Behavior"].Value == "G")
                    {
                        goodKidList.Add(match.Groups["Name"].Value);
                    }
                }
            }

            foreach (var goodKid in goodKidList)
            {
                Console.WriteLine(goodKid);
            }
        }
    }
}
