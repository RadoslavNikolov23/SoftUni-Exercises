using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOriginal = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            //List<int> listToCompare = new List<int>(listOriginal);
            int counter = 0;
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                List<string> inputList = new List<string>(input.Split(" "));
                string comand = inputList[0];

                switch (comand)
                {
                    case "Add":
                        int addNumber = int.Parse(inputList[1]);
                        listOriginal.Add(addNumber);
                        counter++;
                        break;

                    case "Remove":
                        int removeNumber = int.Parse(inputList[1]);
                        listOriginal.Remove(removeNumber);
                        counter++;
                        break;

                    case "RemoveAt":
                        int removeAtIndex = int.Parse(inputList[1]);
                        listOriginal.RemoveAt(removeAtIndex);
                        counter++;
                        break;

                    case "Insert":
                        int insertNumber = int.Parse(inputList[1]);
                        int insertIndex = int.Parse(inputList[2]);
                        listOriginal.Insert(insertIndex, insertNumber);
                        counter++;
                        break;

                    case "Contains":
                        //•	Contains { number} – check if the list contains the number and if so - print "Yes",
                        //otherwise print "No such number".
                        int chechNumber = int.Parse(inputList[1]);
                        if (listOriginal.Contains(chechNumber))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;

                    case "PrintEven":
                        //•	PrintEven – print all the even numbers, separated by a space.
                        string evenNumber = "";
                        bool hasEvenNumber = false;
                        for (int i = 0; i < listOriginal.Count; i++)
                        {
                            if (listOriginal[i] % 2 == 0)
                            {
                                evenNumber += listOriginal[i] + " ";
                                hasEvenNumber = true;
                                // Console.Write(listOriginal[i]);
                            }
                        }

                        if (hasEvenNumber)
                        {
                            Console.WriteLine(evenNumber.TrimEnd(' '));
                        }
                        break;

                    case "PrintOdd":
                        //•	PrintOdd – print all the odd numbers, separated by a space.
                        string oddNumber = "";
                        bool hasOddNumber = false;
                        for (int i = 0; i < listOriginal.Count; i++)
                        {
                            if (listOriginal[i] % 2 == 1)
                            {
                                oddNumber += listOriginal[i] + " ";
                                hasOddNumber = true;
                                // Console.Write(listOriginal[i]);
                            }
                        }

                        if (hasOddNumber)
                        {
                            Console.WriteLine(oddNumber.TrimEnd(' '));
                        }
                        break;

                    case "GetSum":
                        //•	GetSum – print the sum of all the numbers.
                        int sumAllNumber = 0;

                        for (int i = 0; i < listOriginal.Count; i++)
                        {
                            sumAllNumber += listOriginal[i];
                        }
                        Console.WriteLine(sumAllNumber);
                        break;

                    case "Filter":
                        //•	Filter { condition} { number} – print all the numbers that fulfill the given condition.
                        //The condition will be either '<', '>', ">=", "<=".

                        string condition = inputList[1];
                        int numberCondition = int.Parse(inputList[2]);
                        if (condition == "<")
                        {
                            for (int i = 0; i < listOriginal.Count; i++)
                            {
                                if (listOriginal[i] < numberCondition)
                                {
                                    Console.Write(listOriginal[i] + " ");
                                }
                            }
                            Console.WriteLine();

                        }
                        else if (condition == ">")
                        {
                            for (int i = 0; i < listOriginal.Count; i++)
                            {
                                if (listOriginal[i] > numberCondition)
                                {
                                    Console.Write(listOriginal[i] + " ");
                                }
                            }
                            Console.WriteLine();

                        }
                        else if (condition == "<=")
                        {
                            for (int i = 0; i < listOriginal.Count; i++)
                            {
                                if (listOriginal[i] <= numberCondition)
                                {
                                    Console.Write(listOriginal[i] + " ");
                                }
                            }
                            Console.WriteLine();


                        }
                        else if (condition == ">=")
                        {
                            for (int i = 0; i < listOriginal.Count; i++)
                            {
                                if (listOriginal[i] >= numberCondition)
                                {
                                    Console.Write(listOriginal[i] + " ");
                                }
                            }
                            Console.WriteLine();

                        }

                        break;
                }
            }

            if (counter > 0)
                Console.WriteLine(string.Join(" ", listOriginal));


            //After the end command, print the list only if you have made some changes to the original list.
            //Changes are made only from the commands from the previous task.




        }
    }
}
