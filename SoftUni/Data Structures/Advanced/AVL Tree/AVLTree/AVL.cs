namespace AVLTree
{
    using System;

    public class AVL<T> where T : IComparable<T>
    {
        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Height = 1;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Height { get; set; }

            public override string ToString()
            {
                return $"V->[{Value}], H->[{Height}], L->[{Left.Value}], R->[{Right.Value}]";
            }
        }

        public Node Root { get; private set; }

        public bool Contains(T element)
        {
            return Contains(Root, element) != null;
        }

        private Node Contains(Node node, T element)
        {
            if (node is null)
            {
                return null;
            }

            if (element.CompareTo(node.Value) < 0)
            {
                return Contains(node.Left, element);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                return Contains(node.Right, element);
            }

            return node;
        }

        public void Delete(T element)
        {
            Root = Delete(Root, element);
        }

        private Node Delete(Node node, T element)
        {
            if (node is null)
            {
                return null;
            }

            if (element.CompareTo(node.Value) < 0)
            {
                node.Left = Delete(node.Left, element);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = Delete(node.Right, element);
            }
            else
            {
                if (node.Left is null && node.Right is null)
                {
                    return null;
                }
                else if (node.Left is null)
                {
                    node = node.Right;
                }
                else if (node.Right is null)
                {
                    node = node.Left;
                }
                else
                {
                    Node temp = FindSmallestChild(node.Right);
                    node.Value = temp.Value;

                    node.Right = Delete(node.Right, temp.Value);
                }
            }

            node = Balance(node);
            node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;

            return node;
        }

        private Node FindSmallestChild(Node node)
        {
            if (node.Left is null)
            {
                return node;
            }

            return FindSmallestChild(node.Left);
        }

        public void DeleteMin()
        {
            if (Root is null)
            {
                return;
            }

            var smallestElement = FindSmallestChild(Root);

            Root = Delete(Root, smallestElement.Value);
        }

        public void Insert(T element)
        {
            Root = Insert(Root, element);
        }

        private Node Insert(Node node, T element)
        {
            if (node is null)
            {
                return new Node(element);
            }

            if (element.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(node.Left, element);
            }
            else /*if (element.CompareTo(node.Value) > 0)*/
            {
                node.Right = Insert(node.Right, element);
            }
            //else
            //{
            //    throw new InvalidOperationException("No duplicate values allowed!");
            //}

            node = Balance(node);
            node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;

            return node;
        }

        private Node Balance(Node node)
        {
            var balanceFactor = GetHeight(node.Left) - GetHeight(node.Right);

            if (balanceFactor > 1)
            {
                var childBalanceFactor = GetHeight(node.Left.Left) - GetHeight(node.Left.Right);
                if (childBalanceFactor < 0)
                {
                    node.Left = RotateLeft(node.Left);
                }

                node = RotateRight(node);
            }
            else if (balanceFactor < -1)
            {
                var childBalanceFactor = GetHeight(node.Right.Left) - GetHeight(node.Right.Right);
                if (childBalanceFactor > 0)
                {
                    node.Right = RotateRight(node.Right);
                }

                node = RotateLeft(node);
            }

            return node;
        }

        private Node RotateLeft(Node node)
        {
            var right = node.Right;
            node.Right = right.Left;
            right.Left = node;

            node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;

            return right;
        }

        private Node RotateRight(Node node)
        {
            var left = node.Left;
            node.Left = left.Right;
            left.Right = node;

            node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;

            return left;
        }

        private int GetHeight(Node node)
        {
            if (node is null)
            {
                return 0;
            }

            return node.Height;
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(Root, action);
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node is null)
            {
                return;
            }

            EachInOrder(node.Left, action);
            action(node.Value);
            EachInOrder(node.Right, action);
        }
    }
}
