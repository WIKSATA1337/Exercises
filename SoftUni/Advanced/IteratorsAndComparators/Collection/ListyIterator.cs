using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> internalList;
        private int currentIndex = 0;
        public ListyIterator(List<T> list)
        {
            internalList = list;
        }

        public bool Move()
        {
            if (currentIndex < internalList.Count - 1)
            {
                currentIndex++;
                return true;
            }
            return false;
        }
        public void Print()
        {
            if (internalList.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(internalList[currentIndex]);
        }
        public bool HasNext()
        {
            return currentIndex < internalList.Count - 1;
        }
        public void PrintAll()
        {
            if (internalList.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            string result = "";

            foreach (var item in internalList)
            {
                result += item + " ";
            }

            Console.WriteLine(result);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in internalList)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
