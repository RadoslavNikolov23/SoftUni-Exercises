using System;
using System.Collections.Generic;
using System.Text;

namespace _01.CustomListClass
{
    public class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] items;
        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        public int Cout { get; set; }

        public int this[int index]
        {
            get
            {
                if (index >= this.Cout)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range");
                }
                return items[index];
            }
            set
            {
                if (index >= this.Cout)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range");
                }
                items[index] = value;

            }
        }

        public void Resize()
        {
            int[] newArray = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                newArray[i] = this.items[i];
            }

            this.items = newArray;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Cout - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

        }

        private void Shrink()
        {
            int[] newArray = new int[this.items.Length / 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                newArray[i] = this.items[i];
            }

            this.items = newArray;
        }
        public void Add(int item)
        {
            if (this.Cout == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Cout] = item;
            this.Cout++;
        }

        public int RemoveAt(int index)
        {
            if (index >= this.items.Length)
            {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }

            int tempValue = this.items[index];
            this.items[index] = default;
            this.Shift(index);
            this.Cout--;

            if (Cout <= this.items.Length / 4)
            {
                this.Shrink();
            }

            return tempValue;
        }

        public void ShiftToRight(int index)
        {
            for (int i = Cout; i > index; i--)
            {
                this.items[i] = this.items[i - i];
            }

        }
        public void Insert(int index, int item)
        {
            if (index >= this.items.Length)
            {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }

            if (this.Cout == this.items.Length)
            {
                this.Resize();
            }

            this.ShiftToRight(index);
            this.items[index] = item;
            this.Cout++;


        }

        public bool Contains(int element)
        {
            bool contains = false;

            foreach (int item in items)
            {
                if (item == element)
                {
                    contains = true;
                    break;
                }
            }
            return contains;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            int tempValue = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = tempValue;
        }

        public int Find(Predicate<int> predicate)
        {
            int element = default;

            for (int i = 0; i < this.items.Length; i++)
            {
                if (predicate(this.items[i]))
                {
                    element = this.items[i];
                    break;
                }
            }

            return element;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.items.Length; i++)
            {
                action(this.items[i]);
            }

        }

        public void Reverse()
        {
            int[] tempArray = new int[this.items.Length];
            int opposite = 0;

            for (int i = this.items.Length - 1; i >= 0; i--)
            {
                tempArray[opposite++] = this.items[i];
            }

            this.items = tempArray;

        }

        public override string ToString()
        {
            StringBuilder sbResult = new StringBuilder();

            for (int i = 0; i < this.items.Length; i++)
            {
                sbResult.AppendLine(this.items[i].ToString());
            }
            return sbResult.ToString();
        }
    }
}
