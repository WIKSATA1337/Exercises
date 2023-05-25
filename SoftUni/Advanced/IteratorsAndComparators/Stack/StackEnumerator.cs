using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class StackEnumerator<T> : IEnumerator<T>
    {
        private T[] items;
        private int index = 0;
        public StackEnumerator(T[] items)
        {
            this.items = items;
        }

        public T Current => items[index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            return ++index < items.Length;
        }

        public void Reset()
        {
        }
    }
}
