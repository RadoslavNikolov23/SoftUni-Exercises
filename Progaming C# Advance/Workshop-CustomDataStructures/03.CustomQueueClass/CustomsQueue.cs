using System;
using System.Collections.Generic;
using System.Text;

namespace _03.CustomQueueClass
{
    public class CustomsQueue
    {
        private const int initialCapacity = 4;
        private int[] items;
        private int count;

        public CustomsQueue()
        {
            this.items = new int[initialCapacity];
            count = 0;
        }

        public int Count { get { return this.count; } }

        private void Resize()
        {
            int[] tempArray = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                tempArray[i] = this.items[i];
            }

            //this.items.CopyTo(tempArray, 0);   // - Alternative to the for loop!

            this.items = tempArray;

        }


        public void Enqueue(int element)
        {
            if (this.Count == this.items.Length)
            {
                Resize();
            }

            this.items[this.count] = element;
            this.count++;
        }

        public int Dequeue()
        {
            if (this.items.Length == 0)
            {
                throw new InvalidOperationException("CustomQueue is empty");
            }

            int lastElement = this.items[0];

            for (int i = 0; i < this.items.Length - 1; i++)
            {
                items[i] = items[i + 1];
            }
            this.count--;

            return lastElement;
        }

        public int Peek()
        {
            int elementToSee = this.items[0];

            return elementToSee;
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }

        public void Clear()
        {
            this.items = default;
           this.count = 0;


            /*if (this.items.Length == 0)
            {
                throw new InvalidOperationException("CustomQueue is empty");
            }

            int lastElement = this.items[0];

            for (int i = 0; i < this.items.Length - 1; i++)
            {
                items[i] = default;
            }
           
                this.count=0;
            */
          
        }

    }
}
