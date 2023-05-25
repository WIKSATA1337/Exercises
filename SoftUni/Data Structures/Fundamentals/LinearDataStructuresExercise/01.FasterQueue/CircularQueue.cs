namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] elements;
        private int startIndex, endIndex;
            
        public CircularQueue(int capacity = DEFAULT_CAPACITY)
        {
            elements = new T[capacity];
        }

        public int Count { get; set; }

        public T Dequeue()
        {
            if (Count < 1)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T dequeuedElement = elements[startIndex];

            elements[startIndex] = default;

            startIndex++;
            Count--;

            return dequeuedElement;
        }

        public void Enqueue(T item)
        {
            if (Count >= elements.Length)
            {
                Grow();
            }

            elements[endIndex] = item;
            endIndex = (endIndex + 1) % elements.Length;
            Count++;
        }

        private void Grow()
        {
            elements = Resize();

            startIndex = 0;
            endIndex = Count;
        }

        private T[] Resize()
        {
            var newElements = new T[elements.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                newElements[i] = elements[i];
            }

            return newElements;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int currentIndex = 0; currentIndex < Count; currentIndex++)
            {
                yield return elements[(startIndex + currentIndex) % elements.Length];
            }
        }

        public T Peek()
        {
            if (Count < 1)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return elements[startIndex];
        }

        public T[] ToArray()
        {
            List<T> list = new List<T>();
            for (int i = 0; i < Count; i++)
            {
                list.Add(elements[i]);
            }

            return list.ToArray();
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }

}
