namespace CustomQueue
{
    public class CustomQueue<T>
    {
        // Fields and properties
        private T[] queueArray;
        private const int DefaultCapacity = 4;
        private const int FirstInQueue = 0;
        public int Count { get; private set; }

        // Constructor
        public CustomQueue()
        {
            queueArray = new T[DefaultCapacity];
        }

        // Public Methods
        public void Enqueue(T element)
        {
            if (queueArray.Length == Count)
            {
                Resize();
            }

            queueArray[Count] = element;
            Count++;
        }

        public T Dequeue()
        {
            IsEmpty();

            T dequeuedItem = queueArray[FirstInQueue];
            ShiftLeft();
            Count--;

            return dequeuedItem;
        }

        public T Peek()
        {
            IsEmpty();

            return queueArray[FirstInQueue];
        }

        public void Clear()
        {
            queueArray = new T[DefaultCapacity];
            Count = 0;
        }

        // Private methods
        private void Resize()
        {
            var resizedArray = new T[queueArray.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                resizedArray[i] = queueArray[i];
            }

            queueArray = resizedArray;
        }
        private void IsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }
        }

        private void ShiftLeft()
        {
            for (int i = FirstInQueue; i < Count; i++)
            {
                queueArray[i] = queueArray[i + 1];
            }
        }

        // Not a actual Queue method
        private void ForEach(Action<T> action)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                action(queueArray[i]);
            }
        }
    }
}
