using System;

namespace ImplementingLinkedList
{
    public class LinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public int Count { get; set; }

        public void AddFirst(Node<T> node)
        {
            if (Tail == null)
            {
                Head = node;
                Tail = node;
                Count++;
                return;
            }

            Head.Previous = node;
            node.Next = Head;
            Head = node;
            Count++;
        }
        public void AddFirst(T value)
        {
            AddFirst(new Node<T>(value));
        }

        public void AddLast(Node<T> node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
                Count++;
                return;
            }

            Tail.Next = node;
            node.Previous = Tail;
            Tail = node;
            Count++;
        }
        public void AddLast(T value)
        {
            AddLast(new Node<T>(value));
        }

        public T RemoveFirst()
        {
            Node<T> firstNode = Head;

            Head = Head.Next;
            Head.Previous = null;
            firstNode.Next = null;
            Count--;

            return firstNode.Value;
        }
        public T RemoveLast()
        {
            Node<T> lastNode = Tail;

            Tail = Tail.Previous;
            Tail.Next = null;
            lastNode.Previous = null;
            Count--;

            return lastNode.Value;
        }

        public void ForEach(Action<T> callback)
        {
            Node<T> node = Head;

            while (node != null)
            {
                callback(node.Value);
                node = node.Next;
            }
        }
        public void ForEachReverse(Action<T> callback)
        {
            Node<T> node = Tail;

            while (node != null)
            {
                callback(node.Value);
                node = node.Previous;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];

            int counter = 0;

            ForEach(number =>
            {
                array[counter++] = number;
            });

            return array;
        }
    }
}
