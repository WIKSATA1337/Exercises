namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;
        private T value;
        private Tree<T> parent;

        public Tree(T value)
        {
            this.value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parentTree = FindTreeWithKey(parentKey);

            if (parentTree is null)
            {
                throw new ArgumentNullException("Parent doesn't exist.");
            }

            parentTree.children.Add(child);
            child.parent = parentTree;
        }

        private Tree<T> FindTreeWithKey(T parentKey)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();

                if (subTree.value.Equals(parentKey))
                {
                    return subTree;
                }

                foreach (var child in subTree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public IEnumerable<T> OrderBfs()
        {
            // Iterates through all the levels

            // Example:
            // (level 0 (root)) - 99 
            // (level 1) - (1) (2)
            // (level 2) - (3) (4) // (5) (6)

            // Output: 99 1 2 3 4 5 6

            var result = new List<T>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();
                result.Add(subTree.value);

                foreach (var child in subTree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            var result = new Stack<T>();
            var stack = new Stack<Tree<T>>();
            stack.Push(this);

            while (stack.Count > 0)
            {
                var currentTree = stack.Pop();

                foreach (var child in currentTree.children)
                {
                    stack.Push(child);
                }

                result.Push(currentTree.value);
            }

            return result;
        }

        private void DFS(Tree<T> tree, ICollection<T> result)
        {
            foreach (var child in tree.children)
            {
                DFS(child, result);
            }

            result.Add(tree.value);
        }

        public void RemoveNode(T nodeKey)
        {
            var foundNode = FindTreeWithKey(nodeKey);

            if (foundNode is null)
            {
                throw new ArgumentNullException("Node doesn't exist.");
            }

            if (foundNode.parent is null)
            {
                throw new ArgumentException("Cannot remove the tree root.");
            }

            foundNode.parent.children.Remove(foundNode);
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = FindTreeWithKey(firstKey);
            var secondNode = FindTreeWithKey(secondKey);

            if (firstNode is null || secondNode is null)
            {
                throw new ArgumentNullException("Node with this key doesn't exist.");
            }

            var firstParent = firstNode.parent;
            var secondParent = secondNode.parent;

            if (firstParent == null || secondParent == null)
            {
                throw new ArgumentException("Cannot swap the root.");
            }

            var indexOfFirstChild = firstParent.children.IndexOf(firstNode);
            var indexOfSecondChild = secondParent.children.IndexOf(secondNode);

            firstParent.children[indexOfFirstChild] = secondNode;
            secondNode.parent = firstParent;

            secondParent.children[indexOfSecondChild] = firstNode;
            firstNode.parent = secondParent;
        }
    }
}
