using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] items;
        private int count = 0;
        public Stack(T[] items)
        {
            this.items = items;
            count = items.Length;
        }
        public void Push(T item)
        {
            if (count == items.Length)
            {
                Resize();
            }
            items[count] = item;
            count++;
        }
        public T Pop()
        {
            if (count == 0)
            {
                Console.WriteLine("No elements");
                return default(T);
            }
            var poppedItem = items[count - 1];
            items[count - 1] = default(T);
            count--;

            return poppedItem;
        }
        public void ForEach()
        {
            for (int i = count - 1; i >= 0; i--)
            {
                Console.WriteLine(items[i]);
            }
        }
        private void Resize()
        {
            T[] newArr = new T[count * 2];

            for (int i = 0; i < count; i++)
            {
                newArr[i] = items[i];
            }

            items = newArr;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new StackEnumerator<T>(items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
