namespace CustomStack
{
    public class CustomStack<T>
    {
        // Fields and properties
        private T[] stackArray;
        private const int DefaultCapacity = 4;
        public int Count { get; private set; }

        // Constructor
        public CustomStack()
        {
            stackArray = new T[DefaultCapacity];
        }

        // Public methods
        public void Push(T element)
        {
            if (Count == stackArray.Length)
            {
                Resize();
            }

            stackArray[Count] = element;
            Count++;
        }

        public T Pop()
        {
            IsEmpty();

            T poppedElement = stackArray[Count - 1];
            stackArray[Count] = default(T);
            Count--;

            return poppedElement;
        }

        public T Peek()
        {
            IsEmpty();

            return stackArray[Count - 1];
        }

        public void PrintStack()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                Console.WriteLine(stackArray[i]);
            }
        }

        // Private methods
        private void Resize()
        {
            var resizedArray = new T[stackArray.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                resizedArray[i] = stackArray[i];
            }

            stackArray = resizedArray;
        }

        private void IsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }
        }

        // Not a actual Stack method
        private void ForEach(Action<T> action)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                action(stackArray[i]);
            }
        }
    }
}
