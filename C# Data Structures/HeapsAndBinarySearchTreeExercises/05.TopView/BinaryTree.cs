namespace _05.TopView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
        {
            Value = value;
            LeftChild = left;
            RightChild = right;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public List<T> TopView()
        {
            var result = new List<T>();

            var leftSide = GetLeftPath();
            foreach (var element in leftSide)
            {
                result.Add(element);
            }
            
            result.Add(Value);

            var rightSide = GetRightPath();
            foreach (var element in rightSide)
            {
                result.Add(element);
            }

            return result;
        }

        private List<T> GetRightPath()
        {
            var result = new List<T>();

            var currentTree = this;

            while (currentTree.RightChild != null)
            {
                currentTree = currentTree.RightChild;
                result.Add(currentTree.Value);
            }

            return result;
        }

        private List<T> GetLeftPath()
        {
            var result = new List<T>();

            var currentTree = this;

            while (currentTree.LeftChild != null)
            {
                currentTree = currentTree.LeftChild;
                result.Add(currentTree.Value);
            }

            return result;
        }
    }
}
