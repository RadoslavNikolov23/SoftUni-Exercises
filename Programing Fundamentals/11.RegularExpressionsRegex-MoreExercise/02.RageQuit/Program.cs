using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace _02.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {

            string pattern = @"(?<sym>[\D]+)(?<num>[\d]+)";
            string input = Console.ReadLine();

            StringBuilder finalST = new StringBuilder();
            string intputFinal = String.Empty;
            List<char> listCharCont = new List<char>();

            foreach (Match match in Regex.Matches(input, pattern))
            {
                string tempStr = match.Groups[1].Value.ToUpper();
                int number = int.Parse(match.Groups[2].Value);

                if (number == 0)
                {
                    continue;
                }
                else
                {
                    for (int i = 0; i < number; i++)
                    {

                        finalST.Append(tempStr);

                    }

                    for (int i = 0; i < tempStr.Length; i++)
                    {
                        char temp = tempStr[i];


                        if (!listCharCont.Contains(temp))
                        {
                            listCharCont.Add(temp);
                        }


                    }
                }
            }

            Console.WriteLine($"Unique symbols used: {listCharCont.Count}");
            Console.WriteLine($"{finalST}");

        }
    }
}
