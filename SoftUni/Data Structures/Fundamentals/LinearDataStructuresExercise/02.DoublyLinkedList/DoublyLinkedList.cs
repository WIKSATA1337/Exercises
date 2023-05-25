namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }

            public Node(T value)
            {
                Value = value;
            }
        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node(item);

            if (Count == 0)
            {
                head = tail = newNode;
            }
            else
            {
                head.Previous = newNode;
                newNode.Next = head;
                head = newNode;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node(item);

            if (Count == 0)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
            
            Count++;
        }

        public T GetFirst()
        {
            return head == null ? throw new InvalidOperationException("List is empty.") : head.Value;
        }

        public T GetLast()
        {
            return tail == null ? throw new InvalidOperationException("List is empty.") : tail.Value;
        }

        public T RemoveFirst()
        {
            if (Count < 1)
            {
                throw new InvalidOperationException("List is empty.");
            }

            var oldHead = head;

            if (Count == 1)
            {
                head = tail = null;
                Count--;
                return oldHead.Value;
            }

            
            var newHead = head.Next;
            newHead.Previous = null;
            head = newHead;

            Count--;

            return oldHead.Value;
        }

        public T RemoveLast()
        {
            if (Count < 1)
            {
                throw new InvalidOperationException("List is empty.");
            }

            var oldTail = tail;

            if (Count == 1)
            {
                head = tail = null;
                Count--;
                return oldTail.Value;
            }

            var newTail = tail.Previous;
            newTail.Next = null;
            tail = newTail;

            Count--;

            return oldTail.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = head;

            while (node != null)
            {
                yield return node.Value;

                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}