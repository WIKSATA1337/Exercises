using System;
using System.Collections;
using System.Collections.Generic;

namespace Problem02.Stack
{
    public class Stack<T> : IAbstractStack<T>
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

        private Node top;

        public int Count { get; private set;}

        public void Push(T item)
        {
            var node = new Node(item, top);
            top = node;
            Count++;
        }

        public T Pop()
        {
            if (top == null)
            {
                throw new InvalidOperationException("No elements in stack.");
            }

            var poppedElement = top;
            top = poppedElement.Next;

            Count--;

            return poppedElement.Element;
        }

        public T Peek()
        {
            if (top == null)
            {
                throw new InvalidOperationException("No elements in stack.");
            }

            return top.Element;
        }

        public bool Contains(T item)
        {
            if (Count == 0)
            {
                return false;
            }

            if (Count == 1)
            {
                return true;
            }

            var currentNode = top;

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
            var currentNode = top;

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