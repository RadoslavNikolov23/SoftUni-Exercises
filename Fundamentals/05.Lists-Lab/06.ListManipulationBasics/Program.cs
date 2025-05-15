using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOriginal = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                List<string> inputList = new List<string>(input.Split(" "));
                string comand = inputList[0];

                switch (comand)
                {
                    case "Add":
                        int addNumber = int.Parse(inputList[1]);
                        listOriginal.Add(AddToTheEndofList(addNumber));
                        break;
                    case "Remove":
                        int removeNumber = int.Parse(inputList[1]);
                        listOriginal.Remove(RemoveANumber(removeNumber));
                        break;
                    case "RemoveAt":
                        int removeAtIndex = int.Parse(inputList[1]);
                        listOriginal.RemoveAt(RemoveAtIndex(removeAtIndex));
                        break;
                    case "Insert":
                        int insertNumber = int.Parse(inputList[1]);
                        int insertIndex = int.Parse(inputList[2]);
                        listOriginal.Insert(InsertAtIndex(insertIndex), InsertANumber(insertNumber));
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", listOriginal));



            //When you receive the "end" command, print the final state of the list(separated by spaces).





        }

        static int InsertANumber(int insertNumber)
        {
            return insertNumber;

        }

        static int InsertAtIndex(int insertIndex)
        {
            return (insertIndex);
            //•	Insert { number} { index}: insert a number at a given index.

        }

        static int RemoveAtIndex(int removeAtIndex)
        {
            return removeAtIndex;
            //•	RemoveAt { index}: remove a number at a given index.

        }

        static int RemoveANumber(int removeNumber)
        {
            return removeNumber;
            //•	Remove { number}: remove a number from the list.

        }

        static int AddToTheEndofList(int addNumber)
        {
            return addNumber;
            //•	Add { number}: add a number to the end of the list.
        }
    }
}
