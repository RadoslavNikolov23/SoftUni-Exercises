using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> myList = new DoublyLinkedList<int>();

            for(int i = 0; i < 5; i++)
            {
                myList.AddFirst(i);
            }

            myList.RemoveLast();

            int[] array = myList.ToArray();
            myList.ForEach(x => Console.WriteLine(x));
          
        }
    }
}
