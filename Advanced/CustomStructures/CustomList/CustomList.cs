using System;

namespace CustomList
{
    public class CustomList<T> where T : IComparable<T>
    {
        // Fields and properties
        private const int InitialCapacity = 4;
        private T[] internalArray;
        public int Count { get; private set; }
        public T this[int index]
        {
            get
            {
                if (CheckIndex(index))
                {
                    return internalArray[index];
                }

                throw new ArgumentOutOfRangeException();
            }
            set { internalArray[index] = value; }
        }

        // Constructor
        public CustomList()
        {
            internalArray = new T[InitialCapacity];
        }

        // Public methods
        public void Add(T element)
        {
            if (internalArray.Length == Count)
            {
                Resize();
            }

            internalArray[Count] = element;

            Count++;
        }

        public T RemoveAt(int index)
        {
            if (CheckIndex(index))
            {
                T removedItem = internalArray[index];
                internalArray[index] = default(T);
                ShiftLeft(index);
                Count--;

                return removedItem;
            }
            else
            {
                return default(T);
            }
        }

        public void InsertAt(int index, T element)
        {
            if (CheckIndex(index))
            {
                if (internalArray.Length == Count)
                {
                    Resize();
                }

                ShiftRight(index);

                internalArray[index] = element;

                Count++;
            }
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (internalArray[i].CompareTo(element) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (CheckIndex(firstIndex) && CheckIndex(secondIndex))
            {
                T tempValue = internalArray[firstIndex];
                internalArray[firstIndex] = internalArray[secondIndex];
                internalArray[secondIndex] = tempValue;
            }
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(internalArray[i]);
            }
        }

        // Private methods
        private void Resize()
        {
            var resizedArray = new T[internalArray.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                resizedArray[i] = internalArray[i];
            }

            internalArray = resizedArray;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count; i++)
            {
                internalArray[i] = internalArray[i + 1];
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = Count - 1; i >= index; i--)
            {
                internalArray[i + 1] = internalArray[i];
            }
        }

        private bool CheckIndex(int index)
        {
            return index < 0 || index >= Count ? false : true;
        }
    }
}