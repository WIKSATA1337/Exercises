namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);

                return items[index];
            }
            set
            {
                ValidateIndex(index);
                items[Count - 1 - index] = value;
            }
        }

        public int Count { get; private set; }

        private void ValidateIndex(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Add(T item)
        {
            NeedGrowCheck();

            if (Count == 0)
            {
                items[0] = item;
            }
            else
            {
                for (int i = Count; i >= 1; i--)
                {
                    items[i] = items[i - 1];
                }

                items[0] = item;
            }

            Count++;
        }

        private void NeedGrowCheck()
        {
            if (Count == items.Length)
            {
                Grow();
            }
        }

        private void Grow()
        {
            T[] newArray = new T[Count * 2];

            Array.Copy(items, newArray, Count);
            items = newArray;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            NeedGrowCheck();

            for (int i = Count; i >= index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            int itemIndex = IndexOf(item);

            if (itemIndex == -1)
            {
                return false;
            }

            RemoveAt(itemIndex);

            return true;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            for (int i = index; i < Count; i++)
            {
                items[i] = items[i + 1];
            }

            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}