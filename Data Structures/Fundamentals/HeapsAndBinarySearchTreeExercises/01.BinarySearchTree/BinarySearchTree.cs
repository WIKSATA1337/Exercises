namespace _02.BinarySearchTree
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
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

            public int Count { get; set; }
        }

        private Node root;

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        public BinarySearchTree()
        {
        }

        public void Insert(T element)
        {
            root = Insert(element, root);
        }

        public bool Contains(T element)
        {
            Node current = this.FindElement(element);

            return current != null;
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(this.root, action);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node current = FindElement(element);

            return new BinarySearchTree<T>(current);
        }

        public void Delete(T element)
        {
            if (root == null)
            {
                throw new InvalidOperationException("BST is empty!");
            }

            root = Delete(element, root);
        }

        private Node Delete(T element, Node node)
        {
            if (element.Equals(node.Value))
            {
                if (node.Left == null && node.Right == null)
                {
                    // If its leaf or root without children just make it null.
                    node = null;
                    return node;
                }
                else
                {
                    // Element without right child, should be replaced by the left one
                    if (node.Right == null && Count(node.Left) == 1)
                    {
                        node = node.Left;
                        return node;
                    }

                    var smallestLeftNode = GetSmallestLeftNodeOnRight(node);
                    var smallestValue = smallestLeftNode.Value;
                    Delete(smallestLeftNode.Value);
                    node.Value = smallestValue;
                }
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                // Element is bigger than current node value
                node.Right = Delete(element, node.Right);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                // Element is smaller than current node value
                node.Left = Delete(element, node.Left);
            }

            return node;
        }

        private Node GetSmallestLeftNodeOnRight(Node node)
        {
            var currentNode = node.Right;

            while (currentNode.Left != null)
            {
                currentNode = currentNode.Left;
            }

            return currentNode;
        }

        public void DeleteMax()
        {
            if (root == null)
            {
                throw new InvalidOperationException("BST is empty!");
            }

            root = DeleteMax(root);
        }

        private Node DeleteMax(Node node)
        {
            // If the right node is null (obviously if its null that means it's the max element)
            // we return node.Left which will always be null, and when it returns, it sets the max node to null
            // so its deleted.
            if (node.Right == null)
            {
                return node.Left;
            }

            node.Right = DeleteMax(node.Right);
            node.Count = 1 + Count(node.Left) + Count(node.Right);

            return node;
        }

        public void DeleteMin()
        {
            if (root == null)
            {
                throw new InvalidOperationException("BST is empty!");
            }

            root = DeleteMin(root);
        }

        private Node DeleteMin(Node node)
        {
            // If the left node is null (obviously if its null that means it's the min element)
            // we return node.Right which will always be null, and when it returns, it sets the min node to null
            // so its deleted.
            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = DeleteMin(node.Left);
            node.Count = 1 + Count(node.Left) + Count(node.Right);

            return node;
        }

        public int Count()
        {
            return Count(root);
        }

        private int Count(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Count;
            //return 1 + Count(node.Left) + Count(node.Right);
        }

        public int Rank(T element)
        {
            // Rank returns the count of elements that are smaller than the given element.
            return Rank(element, root);
        }

        private int Rank(T element, Node node)
        {
            if (node == null)
            {
                return 0;
            }

            if (element.CompareTo(node.Value) < 0)
            {
                return Rank(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                return 1 + Count(node.Left) + Rank(element, node.Right);
            }

            return Count(node.Left);
        }

        public T Select(int rank)
        {
            // Select returns the rank of the given element.
            Node node = Select(root, rank);

            if (node == null)
            {
                throw new InvalidOperationException();
            }

            return node.Value;
        }

        private Node Select(Node node, int rank)
        {
            if (node == null)
            {
                return null;
            }

            int leftCount = Count(node.Left);

            if (leftCount == rank)
            {
                return node;
            }

            if (leftCount > rank)
            {
                return Select(node.Left, rank);
            }
            else
            {
                return Select(node.Right, rank - (leftCount + 1));
            }
        }

        public T Ceiling(T element)
        {
            // Finds the element that has 1 rank upper than the element we look for.
            // First we find the rank of the element (and add 1 to it (so its the upper element))
            // Then we find the number of the upper element.
            return Select(Rank(element) + 1);
        }

        public T Floor(T element)
        {
            // Finds the element that has 1 rank lower than the element we look for.
            // First we find the rank of the element (and take 1 from it (so its the lower element))
            // Then we find the number of the lower element.
            return Select(Rank(element) - 1);
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            var result = new List<T>();

            Range(root, startRange, endRange, result);

            return result;
        }

        private void Range(Node node, T startRange, T endRange, List<T> queue)
        {
            if (node == null)
            {
                return;
            }

            bool isInLowerRange = startRange.CompareTo(node.Value) < 0;
            bool isInUpperRange = endRange.CompareTo(node.Value) > 0;

            if (isInLowerRange)
            {
                Range(node.Left, startRange, endRange, queue);
            }

            if (startRange.CompareTo(node.Value) <= 0 && endRange.CompareTo(node.Value) >= 0)
            {
                queue.Add(node.Value);
            }

            if (isInUpperRange)
            {
                Range(node.Right, startRange, endRange, queue);
            }
        }

        private Node FindElement(T element)
        {
            Node current = this.root;

            while (current != null)
            {
                if (current.Value.CompareTo(element) > 0)
                {
                    current = current.Left;
                }
                else if (current.Value.CompareTo(element) < 0)
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
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

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = Insert(element, node.Right);
            }

            node.Count = 1 + Count(node.Left) + Count(node.Right);
            return node;
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            EachInOrder(node.Left, action);
            action(node.Value);
            EachInOrder(node.Right, action);
        }
    }
}
