using System;
using System.Collections;
using System.Collections.Generic;

namespace Problem04.SinglyLinkedList
{
    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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

            public Node(T element)
            {
                Element = element;
            }
        }

        private Node head;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newFirst = new Node(item, head);
            head = newFirst;
            Count++;
        }
        
        public void AddLast(T item)
        {
            var newLast = new Node(item);

            if (head == null)
            {
                head = newLast;
            }
            else
            {
                var currentNode = head;

                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Next = newLast;
            }

            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {

            var node = head;

            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        public T GetFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is empty!");
            }

            return head.Element;
        }

        public T GetLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is empty!");
            }

            var node = head;

            while (node.Next != null)
            {
                node = node.Next;
            }

            return node.Element;
        }

        public T RemoveFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is empty!");
            }

            var oldHead = head;
            head = oldHead.Next;

            Count--;
            return oldHead.Element;
        }

        public T RemoveLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is empty!");
            }

            if (Count == 1)
            {
                var lastElement = head.Element;
                head = null;
                Count--;

                return lastElement;
            }

            var node = head;

            while (node.Next.Next != null)
            {
                node = node.Next;
            }

            var removedLastElement = node.Next.Element;

            node.Next = null;

            Count--;
            return removedLastElement;
        }

        IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
    }
}