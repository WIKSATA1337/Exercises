using System;
using System.Collections.Generic;
using System.Drawing;

namespace _03.MinHeap
{
    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        protected List<T> elements;

        public MinHeap()
        {
            elements = new List<T>();
        }

        public int Size => elements.Count;

        private int Left(int i)
        {
            return 2 * i + 1;
        }
        private int Right(int i)
        {
            return 2 * i + 2;
        }
        private int Parent(int i)
        {
            return (i - 1) / 2;
        }

        public void Add(T element)
        {
            elements.Add(element);

            HeapifyUp(Size - 1);
        }

        protected void HeapifyUp(int index)
        {
            if (index <= 0)
            {
                return;
            }
            
            // If last added element is smaller than its parent, we switch their values
            // recursively until the parent element is not smaller than the current element.
            if (elements[index].CompareTo(elements[Parent(index)]) < 0)
            {
                var temp = elements[index];
                elements[index] = elements[Parent(index)];
                elements[Parent(index)] = temp;

                HeapifyUp(Parent(index));
            }
        }

        private void HeapifyDown(int index)
        {
            int minIndex;
            var leftChildIndex = Left(index);
            var rightChildIndex = Right(index);

            if (rightChildIndex >= Size)
            {
                if (leftChildIndex >= Size)
                {
                    return;
                }
                else
                {
                    minIndex = leftChildIndex;
                }
            }
            else
            {
                if (elements[leftChildIndex].CompareTo(elements[rightChildIndex]) <= 0)
                {
                    minIndex = leftChildIndex;
                }
                else
                {
                    minIndex = rightChildIndex;
                }
            }

            if (elements[index].CompareTo(elements[minIndex]) > 0)
            {
                var tmp = elements[minIndex];
                elements[minIndex] = elements[index];
                elements[index] = tmp;

                HeapifyDown(minIndex);
            }
        }

        private void Swap(int parent, int child)
        {
            var temp = elements[parent];
            elements[parent] = elements[child];
            elements[child] = temp;
            HeapifyDown(child);
        }

        public T ExtractMin()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }

            var returnValue = elements[0];

            if (Size == 1)
            {
                elements.RemoveAt(0);
            }
            else
            {
                elements[0] = elements[Size - 1];
                elements.RemoveAt(Size - 1);
                HeapifyDown(0);
            }

            return returnValue;
        }

        public T Peek()
        {
            if (Size <= 0)
            {
                throw new InvalidOperationException();
            }

            return elements[0];
        }
    }
}
