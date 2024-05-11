using System.Text;
using System.Xml.Linq;

namespace General
{
    /// <summary>
    /// https://leetcode.com/problems/serialize-and-deserialize-binary-tree/description/
    /// </summary>
    
    public class SerializeAndDeserializeBinaryTree
    {
        /// Depth First Search with preorder
                public string Serialize(TreeNode root)
                {
                    if (root == null)
                        return string.Empty;

                    var sb = new StringBuilder();

                    Traverse(root, sb);

                    return sb.ToString();

                    void Traverse(TreeNode node, StringBuilder sb)
                    {
                        if (node == null)
                        {
                            sb.Append("null,");
                            return;
                        }

                        sb.Append($"{node.val},");
                        Traverse(node.left, sb);
                        Traverse(node.right, sb);
                    }
                }

                // example 
                public TreeNode Deserialize(string data)
                {
                    if (string.IsNullOrWhiteSpace(data))
                        return null;

                    var treeNodeds = data.Split(",");

                    var root = new TreeNode(int.Parse(treeNodeds[0]));
                    var index = 0;

                    Traverse(root, treeNodeds, ref index);

                    return root;

                    TreeNode Traverse(TreeNode node, string[] treeNodes, ref int index)
                    {
                        index++;
                        if (treeNodes[index] != "null")
                        {
                            node.left = new TreeNode(int.Parse(treeNodeds[index]));
                            Traverse(node.left, treeNodes, ref index);
                        }

                        index++;
                        if (treeNodes[index] != "null")
                        {
                            node.right = new TreeNode(int.Parse(treeNodeds[index]));
                            Traverse(node.right, treeNodes, ref index);
                        }

                        return node;
                    }
                }
    }

    // TRY TO SOLVE USING TREE INDEX currentIndex * 2 + 1/2 (L/R), but need to create partition.
    /*        private static readonly char _delimiterBetweenNode = ',';
            private static readonly char _delimiterBetweenParitition = ';';
            private static readonly string _emptyNode = "null";
            private static readonly int _conditionToDivideTree = 4;

            private int _partitionSize;

            public string Serialize(TreeNode root)
            {
                if (root == null)
                    return string.Empty;

                var subtree = new List<string>[1000];
                TraverseV3(root, nodeIndex: 0, subtree, 0);

                //            Traverse(root, result, 0, 0, ref numberOfProcessedNodes, ref currentPartition);


                var sb = new StringBuilder();

                for (var i = 0; i < subtree.Length; i++)
                {
                    var partition = subtree[i];
                    if (partition == null)
                        continue;

                    sb.AppendJoin(_delimiterBetweenNode, partition);
                    sb.Append(_delimiterBetweenParitition);

                }

                return sb.ToString();

                static void TraverseV3(TreeNode node, int nodeIndex, List<string>[] subtree, int deepLevel)
                {
                    if (subtree[deepLevel] is null)
                    {
                        subtree[deepLevel] = new List<string>();
                    }

                    subtree[deepLevel].Add(node?.val.ToString() ?? _emptyNode);

                    if (node == null)
                        return;

                    TraverseV3(node.left, nodeIndex * 2 + 1, subtree, deepLevel + 1);
                    TraverseV3(node.right, nodeIndex * 2 + 2, subtree, deepLevel + 1);
                }

                *//*            void TraverseV2(TreeNode node, int nodeIndex, int deepLevel, List<List<int?>> subtree, int currentPartition)
                            {
                                if (node == null) 
                                    return;

                                if (subtree.ElementAt(currentPartition) is null)
                                {
                                    subtree[currentPartition] = new List<int?>();
                                }

                                if (deepLevel == _conditionToDivideTree)
                                {
                                    currentPartition++;
                                }

                                var leftNodeIndex = nodeIndex * 2 + 1;
                                var rightNodeIndex = nodeIndex * 2 + 2;

                                TraverseV2(node.left, leftNodeIndex, deepLevel + 1, subtree, currentPartition);
                                TraverseV2(node.right, leftNodeIndex, deepLevel + 1, subtree, currentPartition);

                                static int CalculateNextPartition(int currentPartition, int deepLevel)
                                {

                                }

                                *//*                if (subtree.ElementAtOrDefault(currentPartition) is null)
                                                {
                                                    subtree.Add(item: new string[_partitionSize]);
                                                }

                                                if (deepLevel == _conditionToDivideTree)
                                                {
                                                    subtree[currentPartition][nodeIndex] = node.val.ToString();
                                                    currentPartition++;

                                                    TraverseV2(node.left, nodeIndex: 0, deepLevel: 0, subtree, ref currentPartition);
                                                    TraverseV2(node.right, nodeIndex: 0, deepLevel: 0, subtree, ref currentPartition);
                                                }
                                                else*//*
                            }*/

    /*     static void Traverse(TreeNode node, List<List<(int? Value, long Pos)>> result, long currentIndex, int deepLevel, ref int numberOfProcessedNodes, ref int currentPartition)
         {
             if (deepLevel == _deepLevel)
             {
                 Traverse(node.left, result, 0, 0, ref numberOfProcessedNodes, ref currentPartition);
                 Traverse(node.right, result, 0, 0, ref numberOfProcessedNodes, ref currentPartition);

                 return;
             }

             numberOfProcessedNodes++;
             if (numberOfProcessedNodes == _numberOfNodesToMakePartition) 
             {
                 currentPartition++;
                 result.Add(new List<(int? Value, long Pos)>());
                 currentIndex = 0;
                 numberOfProcessedNodes = 0;
             }

             result[currentPartition].Add((node?.val, currentIndex));

             if (node is null)
                 return;

             var leftNodePos = (currentIndex * 2) + 1;
             var rightNodePos = (currentIndex * 2) + 2;

             Traverse(node.left, result, leftNodePos, ref numberOfProcessedNodes, ref currentPartition);
             Traverse(node.right, result, rightNodePos, ref numberOfProcessedNodes, ref currentPartition);
         }
    *//*
}

private static int CalculatePartitionArrayNumber(long index, int currentPartitionArrayNumber)
{
    if (index > int.MaxValue)
    {
        return currentPartitionArrayNumber++;
    }

    return currentPartitionArrayNumber;
}

// example 
public TreeNode Deserialize(string data)
{
    if (string.IsNullOrWhiteSpace(data))
        return null;

    var partitions = data.Split(_delimiterBetweenParitition).Select(k => k.Split(_delimiterBetweenNode)).ToList();

    var root = new TreeNode(int.Parse(partitions[0][0]));

    TraverseV2(root, partitions, 0, 0, 0);

    return root;

    static void TraverseV2(TreeNode node, List<string[]> partitions, int prevIndex, int currentIndex, int deepLevel)
    {
        if (node == null)
            return;

        var leaf = partitions[deepLevel + 1];
        var leftIndex = currentIndex;
        var rightIndex = currentIndex + 1;

        for (var i = 0; i < leaf.Length; i++)
        {
            if (leftIndex < leaf.Length && leaf[i] != _emptyNode)
                node.left = new TreeNode(int.Parse(leaf[i]));
            };

            if (rightIndex < leaf.Length && leaf[i + 1] != _emptyNode)
                node.right = new TreeNode(int.Parse(leaf[i + 1]));


        }

        if (leftIndex < leaf.Length && leaf[leftIndex] != _emptyNode)
            node.left = new TreeNode(int.Parse(leaf[leftIndex]));

        if (rightIndex < leaf.Length && leaf[rightIndex] != _emptyNode)
            node.right = new TreeNode(int.Parse(leaf[rightIndex]));

        TraverseV2(node.left, partitions, leftIndex, leftIndex, deepLevel + 1);
        TraverseV2(node.right, partitions, rightIndex, rightIndex, deepLevel + 1);
    }

    static void Traverse(TreeNode node, string[] source, long currentIndex)
    {
        if (node == null)
            return;

        var leftNodePos = (currentIndex * 2) + 1;
        var rightNodePos = (currentIndex * 2) + 2;

        if (leftNodePos < source.Length && source[leftNodePos] != null && int.TryParse(source[leftNodePos], out var val1))
        {
            node.left = new TreeNode(val1);
            Traverse(node.left, source, leftNodePos);
        }

        if (rightNodePos < source.Length && source[rightNodePos] != null && int.TryParse(source[rightNodePos], out var val2))
        {
            node.right = new TreeNode(val2);
            Traverse(node.right, source, rightNodePos);
        }
    }
}

*//*
 *         public string Serialize(TreeNode root)
{
    if (root == null)
        return string.Empty;

    var result = new List<(int? Value, int Pos)>();

    Traverse(root, result, 0);

    var maxPosition = result.Max(x => x.Pos);

    var serialized = new string[maxPosition + 1];

    for (var i = 0; i < serialized.Length; i++)
        serialized[i] = _emptyNode;

    foreach (var item in result)
    {
        if (item.Value.HasValue)
            serialized[item.Pos] = item.Value.Value.ToString();
    }

    return string.Join(_delimiterBetweenNode, serialized);

    static void Traverse(TreeNode node, List<(int? Value, int Pos)> result, int currentIndex)
    {
        result.Add((node?.val, currentIndex));

        if (node is null)
            return;

        var leftNodePos = (currentIndex * 2) + 1;
        var rightNodePos = (currentIndex * 2) + 2;

        Traverse(node.left, result, leftNodePos);
        Traverse(node.right, result, rightNodePos);
    }
}

// example 
public TreeNode Deserialize(string data)
{
    if (string.IsNullOrWhiteSpace(data))
        return null;

    var source = data.Split(_delimiterBetweenNode);
    var root = new TreeNode(int.Parse(source[0]));

    Traverse(root, source, 0);

    return root;

    static void Traverse(TreeNode node, string[] source, int currentIndex)
    {
        if (node == null) 
            return;

        var leftNodePos = (currentIndex * 2) + 1;
        var rightNodePos = (currentIndex * 2) + 2;

        if (source[leftNodePos] != _emptyNode)
        {
            node.left = new TreeNode(int.Parse(source[leftNodePos]));
            Traverse(node.left, source, leftNodePos);
        }

        if (source[rightNodePos] != _emptyNode)
        {
            node.right = new TreeNode(int.Parse(source[rightNodePos]));
            Traverse(node.right, source, rightNodePos);
        }
    }
}
 *//*
}*/

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}