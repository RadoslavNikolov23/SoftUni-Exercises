using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CustomListClass
{
    public class Program
    {
        static void Main()
        {
            List<int> listNew = new List<int>() { 1, 2, 2, 3, };
            CustomList listCustom = new CustomList();

            for (int i = 0; i < 4; i++)
            {
                listCustom.Add(i + 100);
            }

            int one = 2;
            int isOne = listNew.Find(x => x == 2);


            listNew.Reverse();

            int isTwo = listCustom.Find(x => x == 102);

            Predicate<int> predicate = x => x == 102;

            Console.WriteLine(isTwo);
            Console.WriteLine();

            listCustom.ForEach(x => Console.WriteLine(x));
            listCustom.Reverse();


            Console.WriteLine();
            Console.WriteLine(listCustom);
        }
    }
}
