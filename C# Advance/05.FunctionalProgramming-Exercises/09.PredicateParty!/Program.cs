using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<string, string, bool> startsWith = (x, arg) => x.StartsWith(arg);
            Func<string, string, bool> endsWith = (x, arg) => x.EndsWith(arg);
            Predicate<int> doTheListHavePeople = x => x > 0;

            List<string> listOfPeople = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string commands = Console.ReadLine();

            while (commands != "Party!")
            {
                string[] array = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstCommand = array[0], condition = array[1], arg = array[2];

                switch (firstCommand)
                {
                    case "Remove":
                        RemoveFromList(listOfPeople, condition, arg);
                        break;
                    case "Double":
                        DoubleToTheList(listOfPeople, condition, arg);
                        break;
                    default:
                        break;
                }

                commands = Console.ReadLine();
            }


            if (doTheListHavePeople(listOfPeople.Count))
            {
                Console.WriteLine($"{string.Join(", ", listOfPeople)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

            void RemoveFromList(List<string> listOfPeople, string condition, string arg)
            {
                if (condition == "StartsWith")
                {
                    for (int i = listOfPeople.Count - 1; i >= 0; i--)
                    {
                        if (startsWith(listOfPeople[i],arg))
                            listOfPeople.RemoveAt(i);
                    }

                }
                else if (condition == "EndsWith")
                {
                    for (int i = listOfPeople.Count - 1; i >= 0; i--)
                    {
                        if (endsWith(listOfPeople[i],arg))
                            listOfPeople.RemoveAt(i);
                    }
                }
                else if (condition == "Length")
                {
                    int lengtName = int.Parse(arg);
                    for (int i = listOfPeople.Count - 1; i >= 0; i--)
                    {
                        if (listOfPeople[i].Length == lengtName)
                            listOfPeople.RemoveAt(i);
                    }

                }

            }

            void DoubleToTheList(List<string> listOfPeople, string condition, string arg)
            {
                if (condition == "StartsWith")
                {
                    for (int i = 0; i < listOfPeople.Count; i++)
                    {
                        if (startsWith(listOfPeople[i], arg))
                        {
                            listOfPeople.Insert(i, listOfPeople[i]);
                            i++;
                        }
                    }

                }
                else if (condition == "EndsWith")
                {
                    for (int i = 0; i < listOfPeople.Count; i++)
                    {
                        if (endsWith(listOfPeople[i], arg))
                        {
                            listOfPeople.Insert(i, listOfPeople[i]);
                            i++;
                        }
                    }
                }
                else if (condition == "Length")
                {
                    int lengtName = int.Parse(arg);

                    for (int i = 0; i < listOfPeople.Count; i++)
                    {
                        if (listOfPeople[i].Length == lengtName)
                        {
                            listOfPeople.Insert(i, listOfPeople[i]);
                            i++;
                        }
                    }
                }

            }
        }


    }
}
