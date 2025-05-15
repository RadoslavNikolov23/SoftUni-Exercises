using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> listOne = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> listTwo = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> finalList = new List<int>();

            if (listOne.Count > listTwo.Count)
            {
                for (int i = 0; i < listOne.Count; i++)
                {
                    if (listTwo.Count == i)
                    {
                        //finalList.Insert(i,listOne);
                        for (int k = i; k < listOne.Count; k++)
                        {
                            finalList.Add(listOne[k]);

                        }
                        break;

                    }
                    finalList.Add(listOne[i]);
                    finalList.Add(listTwo[i]);

                }
            }
            else
            {
                for (int i = 0; i < listTwo.Count; i++)
                {
                       if (listOne.Count == i)
                    {
                        //finalList.AddRange(listTwo);
                        for (int k = i; k < listTwo.Count; k++)
                        {
                            finalList.Add(listTwo[k]);

                        }
                        break;

                    }
                    finalList.Add(listOne[i]);
                    finalList.Add(listTwo[i]);
                 
                }
            }
            Console.WriteLine(string.Join(" ", finalList));



        }
    }
}
