using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOne = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> listTwo = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> newList = new List<int>();

            int starNumber;
            int endNumber;

            if (listOne.Count > listTwo.Count)
            {
                int starIndexListTwo = listTwo.Count - 1;
                for (int i = 0; i < listOne.Count; i++)
                {
                    newList.Add(listOne[i]);

                    if (starIndexListTwo >= 0)
                    {
                        newList.Add(listTwo[starIndexListTwo--]);
                    }

                }


                if (newList[newList.Count - 1] > newList[newList.Count - 2])
                {
                    starNumber = newList[newList.Count - 2];
                    endNumber = newList[newList.Count - 1];
                }
                else
                {
                    starNumber = newList[newList.Count - 1];
                    endNumber = newList[newList.Count - 2];
                }
            }
            else
            {
                int starIndexListOne = 0;

                for (int i = listTwo.Count-1; i >= 0; i--)
                {
                    newList.Add(listTwo[i]);

                    if (starIndexListOne <=listOne.Count-1)
                    {
                        newList.Add(listOne[starIndexListOne++]);
                    }

                }

                if (newList[newList.Count - 1] > newList[newList.Count - 2])
                {
                    starNumber = newList[newList.Count - 2];
                    endNumber = newList[newList.Count - 1];
                }
                else
                {
                    starNumber = newList[newList.Count - 1];
                    endNumber = newList[newList.Count - 2];
                }

            }
           

         

  

            List<int> finalList = new List<int>();

            foreach (var number in newList)
            {
                if(number>starNumber && number < endNumber)
                {
                    finalList.Add(number);
                }

            }

            finalList.Sort();
            Console.WriteLine(string.Join(" ",finalList));

        }
    }
}
