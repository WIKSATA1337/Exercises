namespace Tree
{
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {
            var result = new List<List<int>>();
            var leafs = GetLeafs();

            foreach (var leaf in leafs)
            {
                if (LeafHasSum(leaf) == sum)
                {
                    var foundPath = GetPath(leaf);
                    result.Add(foundPath);
                }
            }

            return result;
        }

        private List<int> GetPath(Tree<int> leaf)
        {
            var list = new List<int>();

            while (leaf != null)
            {
                list.Add(leaf.Key);
                leaf = leaf.Parent;
            }

            list.Reverse();

            return list;
        }

        private int LeafHasSum(Tree<int> leaf)
        {
            int sum = 0;

            while (leaf != null)
            {
                sum += leaf.Key;
                leaf = leaf.Parent;
            }

            return sum;
        }

        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            var result = new List<Tree<int>>();

            DFS(this, sum, 0, result);

            return result;
        }

        private int DFS(Tree<int> node, int searchSum, int currentSum, List<Tree<int>> result)
        {
            if (node == null)
            {
                return 0;
            }

            currentSum = node.Key;

            foreach (var child in node.Children)
            {
                currentSum += DFS(child, searchSum, currentSum, result);
            }

            if (currentSum == searchSum)
            {
                result.Add(node);
            }

            return currentSum;
        }

        private IEnumerable<Tree<int>> GetLeafs()
        {
            var result = new List<Tree<int>>();
            var queue = new Queue<Tree<int>>();

            var currentNode = this;
            queue.Enqueue(currentNode);

            while (queue.Any())
            {
                var node = queue.Dequeue();

                if (node.Children.Count == 0)
                {
                    result.Add(node);
                }

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }
    }
}
