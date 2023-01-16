namespace _02.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public Node(T value)
            {
                Value = value;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        private Node root;

        public BinarySearchTree() {}

        private BinarySearchTree(Node node)
        {
            PreOrderCopy(node);
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            Insert(node.Value);
            PreOrderCopy(node.Left);
            PreOrderCopy(node.Right);
        }

        public bool Contains(T element) 
        {
            return FindNode(element) != null;
        }

        private Node FindNode(T element)
        {
            var currentNode = root;

            while (currentNode != null)
            {
                if (element.CompareTo(currentNode.Value) > 0)
                {
                    currentNode = currentNode.Right;
                }
                else if (element.CompareTo(currentNode.Value) < 0)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    return currentNode;
                }
            }

            return null;
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(action, root);
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }

            EachInOrder(action, node.Left);
            action.Invoke(node.Value);
            EachInOrder(action, node.Right);
        }

        public void Insert(T element)
        {
            root = Insert(element, root);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                // Insert it
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                // Go left
                node.Left = Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                // Go Right
                node.Right = Insert(element, node.Right);
            }

            return node;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var node = FindNode(element);

            if (node == null)
            {
                return null;
            }

            return new BinarySearchTree<T>(node);
        }
    }
}
