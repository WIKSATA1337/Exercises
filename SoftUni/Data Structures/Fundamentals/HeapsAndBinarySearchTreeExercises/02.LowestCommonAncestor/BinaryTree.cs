namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
            if (leftChild != null)
            {
                this.LeftChild.Parent = this;
            }

            if (rightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            BinaryTree<T> firstNode = FindBfs(first, this);
            BinaryTree<T> secondNode = FindBfs(second, this);

            if (firstNode == null | secondNode == null)
            {
                throw new InvalidOperationException();
            }

            var firstNodeAncestors = FindAncestors(firstNode);
            var secondtNodeAncestors = FindAncestors(secondNode);

            return firstNodeAncestors.Intersect(secondtNodeAncestors).First();
        }

        private List<T> FindAncestors(BinaryTree<T> node)
        {
            var result = new List<T>();

            var currentNode = node;

            while (currentNode != null)
            {
                result.Add(currentNode.Value);
                currentNode = currentNode.Parent;
            }

            return result;
        }

        private BinaryTree<T> FindBfs(T element, BinaryTree<T> node)
        {
            var queue = new Queue<BinaryTree<T>>();

            queue.Enqueue(node);

            while (queue.Any())
            {
                var currentNode = queue.Dequeue();

                if (element.Equals(currentNode.Value))
                {
                    return currentNode;
                }

                if (currentNode.LeftChild != null)
                {
                    queue.Enqueue(currentNode.LeftChild);
                }
                if (currentNode.RightChild != null)
                {
                    queue.Enqueue(currentNode.RightChild);
                }
            }

            return null;
        }
    }
}
