using System;
using System.Linq;
using System.Collections.Generic;


namespace _01.RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> inputList = Console.ReadLine().Split().ToList();
            var number = new Random();

            for (int i = 0; i <= inputList.Count-1; i++)
            {

                int variant = number.Next(0,inputList.Count);
                string tempOne = inputList[variant];
                string tempTwo = inputList[i];

                inputList[variant] = tempTwo;
                inputList[i] = tempOne;
                
            }
            foreach (var item in inputList)
            {
                Console.WriteLine(item);
            }


        }
    }
}
