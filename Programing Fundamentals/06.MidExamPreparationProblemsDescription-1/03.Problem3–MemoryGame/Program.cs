using System;
using System.Linq;
using System.Collections.Generic;


/*
a 2 4 a 2 4
0 3
0 2
0 1
0 1
end

 */
namespace _03.Problem3_MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> listNmbers = Console.ReadLine().Split().ToList();
            int countMoves = 0;
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                countMoves++;
                string[] inputNumbers = input.Split();
                int firstIndex = int.Parse(inputNumbers[0]);
                int secondIndex = int.Parse(inputNumbers[1]);
           

                if (firstIndex == secondIndex
                    || (firstIndex < 0 || firstIndex >= listNmbers.Count)
                    || (secondIndex < 0 || secondIndex >= listNmbers.Count))
                {
                    string element = $"-{countMoves}a";
                    string[] tempElement = new string[] { element, element };
                    listNmbers.InsertRange(listNmbers.Count / 2, tempElement);
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    continue;
                }

                if (listNmbers[firstIndex] == listNmbers[secondIndex])
                {
                    string tempElem = listNmbers[firstIndex];
                    if (firstIndex > secondIndex)
                    {
                        listNmbers.RemoveAt(firstIndex);
                        listNmbers.RemoveAt(secondIndex);
                    }
                    else if (secondIndex>firstIndex)
                    {
                        listNmbers.RemoveAt(secondIndex);
                        listNmbers.RemoveAt(firstIndex);
                    }
                   
                    Console.WriteLine($"Congrats! You have found matching elements - {tempElem}!");
                }
                else if (listNmbers[firstIndex] != listNmbers[secondIndex])
                {
                    Console.WriteLine("Try again!");
                }

                if (listNmbers.Count == 0)
                {
                    Console.WriteLine($"You have won in {countMoves} turns!");
                    break;
                }

            }

            if (input == "end")
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ",listNmbers));
            }


        }
    }
}