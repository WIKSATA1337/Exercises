namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                Element = element;
                Next = next;
            }
        }

        private Node head;

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            var enqueued = new Node(item, null);

            if (head == null)
            {
                head = enqueued;
                Count++;
                return;
            }

            SetLast(enqueued);

            Count++;
        }

        private void SetLast(Node enqueued)
        {
            var currentNode = head;

            while (currentNode != null)
            {
                if (currentNode.Next == null)
                {
                    currentNode.Next = enqueued;
                    break;
                }

                currentNode = currentNode.Next;
            }
        }

        public T Dequeue()
        {
            if (head == null)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            var oldHead = head;
            head = oldHead.Next;

            Count--;

            return oldHead.Element;
        }

        public T Peek()
        {
            if (head == null)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            return head.Element;
        }

        public bool Contains(T item)
        {
            var currentNode = head;

            while (currentNode != null)
            {
                if (currentNode.Element.Equals(item))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = head;

            while (currentNode != null)
            {
                yield return currentNode.Element;

                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
    }
}