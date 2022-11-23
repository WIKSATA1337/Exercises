namespace Tree
{
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTreeFactory
    {
        private Dictionary<int, IntegerTree> nodesByKey;

        public IntegerTreeFactory()
        {
            this.nodesByKey = new Dictionary<int, IntegerTree>();
        }

        public IntegerTree CreateTreeFromStrings(string[] input)
        {
            foreach (var miniTree in input)
            {
                int[] miniTreeData = miniTree
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                int parent = miniTreeData[0];
                int child = miniTreeData[1];

                AddEdge(parent, child);
            }

            return GetRoot();
        }

        public IntegerTree CreateNodeByKey(int key)
        {
            if (!nodesByKey.ContainsKey(key))
            {
                nodesByKey.Add(key, new IntegerTree(key));
            }

            return nodesByKey[key];
        }

        public void AddEdge(int parent, int child)
        {
            var parentNode = CreateNodeByKey(parent);
            var childNode = CreateNodeByKey(child);

            childNode.AddParent(parentNode);
            parentNode.AddChild(childNode);
        }

        public IntegerTree GetRoot()
        {
            foreach (var kvp in nodesByKey)
            {
                if (kvp.Value.Parent is null)
                {
                    return kvp.Value;
                }
            }

            return null;
        }
    }
}
