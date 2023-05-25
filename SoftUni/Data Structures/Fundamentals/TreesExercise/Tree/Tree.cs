namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;
        public Tree(T key, params Tree<T>[] children)
        {
            Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                AddChild(child);
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            children.Add(child);
            child.Parent = this;
        }

        public void AddParent(Tree<T> parent)
        {
            Parent = parent;
        }

        public string AsString()
        {
            StringBuilder sb = new StringBuilder();

            DfsAsString(sb, this, 0);

            return sb.ToString().Trim();
        }

        private void DfsAsString(StringBuilder sb, Tree<T> tree, int indent)
        {
            sb.Append(' ', indent)
                .AppendLine(tree.Key.ToString());

            foreach (var child in tree.children)
            {
                DfsAsString(sb, child, indent+2);
            }
        }

        public IEnumerable<T> GetInternalKeys()
        {
            return BfsWithResultKeys(tree => tree.Parent != null && tree.children.Count > 0)
                .Select(tree => tree.Key);
        }

        public IEnumerable<T> GetLeafKeys()
        {
            return BfsWithResultKeys(tree => tree.children.Count == 0)
                .Select(tree => tree.Key);
        }

        private IEnumerable<Tree<T>> BfsWithResultKeys(Predicate<Tree<T>> predicate)
        {
            var result = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Any())
            {
                var currentSubTree = queue.Dequeue();

                if (predicate.Invoke(currentSubTree))
                {
                    result.Add(currentSubTree);
                }

                foreach (var child in currentSubTree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public T GetDeepestKey()
        {
            return GetDeepestNode().Key;
        }

        private Tree<T> GetDeepestNode()
        {
            var leafs = BfsWithResultKeys(tree => tree.children.Count == 0);

            Tree<T> deepestNode = null;
            int currentMaxDepth = 0;

            foreach (var leaf in leafs)
            {
                var depth = GetDepth(leaf);

                if (depth > currentMaxDepth)
                {
                    currentMaxDepth = depth;
                    deepestNode = leaf;
                }
            }

            return deepestNode;
        }

        private int GetDepth(Tree<T> leaf)
        {
            int depth = 0;

            while (leaf.Parent != null)
            {
                depth++;
                leaf = leaf.Parent;
            }

            return depth;
        }

        public IEnumerable<T> GetLongestPath()
        {
            var result = new List<T>();
            var deepestNode = GetDeepestNode();

            while (deepestNode != null)
            {
                result.Add(deepestNode.Key);
                deepestNode = deepestNode.Parent;
            }

            result.Reverse();

            return result;
        }
    }
}
