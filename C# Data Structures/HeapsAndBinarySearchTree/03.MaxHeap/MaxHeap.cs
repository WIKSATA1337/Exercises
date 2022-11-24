namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> elements;

        public MaxHeap()
        {
            elements = new List<T>();
        }

        public int Size => elements.Count;

        public void Add(T element)
        {
            elements.Add(element);

            HeapifyUp(Size - 1);
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;

            while (index > 0 && elements[index].CompareTo(elements[parentIndex]) > 0)
            {
                Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void HeapifyDown(int index)
        {
            int biggerChildIndex = GetBiggerElementIndex(index);

            while (IsIndexValid(biggerChildIndex) 
                && elements[biggerChildIndex].CompareTo(elements[index]) > 0)
            {
                Swap(biggerChildIndex, index);

                index = biggerChildIndex;
                biggerChildIndex = GetBiggerElementIndex(index);
            }
        }

        private int GetBiggerElementIndex(int index)
        {
            int leftChild = index * 2 + 1;
            int rightChild = index * 2 + 2;

            if (rightChild < Size)
            {
                return elements[leftChild].CompareTo(elements[rightChild]) > 0
                    ? leftChild : rightChild;
            }
            else if (leftChild < Size)
            {
                return leftChild;
            }
            else
            {
                return -1;
            }
        }

        private bool IsIndexValid(int index)
        {
            return index >= 0 && index < Size;
        }

        private void Swap(int index, int parentIndex)
        {
            T parentValue = elements[parentIndex];
            elements[parentIndex] = elements[index];
            elements[index] = parentValue;
        }

        public T ExtractMax()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Heap is empty!");
            }

            T element = elements[0];
            Swap(0, Size - 1);
            elements.RemoveAt(Size - 1);
            HeapifyDown(0);

            return element;
        }

        public T Peek()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Heap is empty!");
            }

            return elements[0];
        }
    }
}
