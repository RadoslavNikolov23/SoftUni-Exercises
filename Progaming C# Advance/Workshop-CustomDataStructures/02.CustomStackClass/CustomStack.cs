using System;
using System.Collections.Generic;
using System.Text;

namespace _02.CustomStackClass
{
    public class CustomStack
    {
        private const int initialCapacity = 4;
        private int[] items;
        private int count;

        public CustomStack()
        {
            this.items = new int[initialCapacity];
            count = 0;
        }

        public int Count { get { return this.count; } }

        public void Resize()
        {
            int[] tempArray = new int[this.items.Length * 2];

            for(int i = 0; i < this.items.Length; i++)
            {
                tempArray[i] = this.items[i];
            }
            this.items = tempArray;
        }

        public bool ChechIndex(int index)
        {
            if (index >= this.items.Length - 1)
            {
                 throw new ArgumentOutOfRangeException("Index is out of range");
                return false;
            }
            return true;
        }
        public void Push(int element)
        {
            if (this.Count == this.items.Length)
            {
                Resize();
            }

            this.items[this.count] = element;
            this.count++;
        }
        
        public int Pop()
        {
            if (this.items.Length == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }

            int lastElement = this.items[this.count - 1];
            this.count--;

            return lastElement;
        }

        public int Peek()
        {
            int elementToSee = this.items[this.count - 1];

            return elementToSee;
        }

        public void ForEach(Action<object> action)
        {
            for(int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }
    }
}
