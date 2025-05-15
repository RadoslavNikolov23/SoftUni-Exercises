using System;
using System.Text.RegularExpressions;


namespace _01.WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"(@{6,10}|#{6,10}|\${6,10}|\^{6,10})";


            string[] input = Console.ReadLine().Split(',', StringSplitOptions.TrimEntries);

            foreach (var ticket in input)
            {

                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                var leftSide = ticket.Substring(0, 10);
                var rightSide = ticket.Substring(10);


                var leftSideMatch = Regex.Match(leftSide, pattern).Value;
                var rightSideMatch = Regex.Match(rightSide, pattern).Value;


                if (string.IsNullOrEmpty(leftSideMatch) || string.IsNullOrEmpty(rightSideMatch) || leftSideMatch[0] != rightSideMatch[0])
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                    continue;
                }
                else
                {
                    int matchLength = Math.Min(leftSideMatch.Length, rightSideMatch.Length);
                    var winningSymbol = leftSideMatch[0];

                    if (matchLength >= 6 && matchLength <= 9)
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - {matchLength}{winningSymbol}");
                    }
                    else if (matchLength > 9)
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - {matchLength}{winningSymbol} Jackpot!");
                    }
                }


            }

        }
    }
}
