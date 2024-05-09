using System.Text;
using System.Xml.Linq;

namespace General
{
    /// <summary>
    /// https://leetcode.com/problems/serialize-and-deserialize-binary-tree/description/
    /// </summary>
    public class SerializeAndDeserializeBinaryTree
    {
        private static readonly char _delimiterBetweenNode = ',';
        private static readonly char _delimiterBetweenParitition = ';';
        private static  readonly string _emptyNode = "null";
        private static readonly int _numberOfNodesToMakePartition = 13; // 2^15

        public string Serialize(TreeNode root)
        {
            int numberOfProcessedNodes = 0;
            int currentPartition = 0;

            if (root == null)
                return string.Empty;

            var result = new List<List<(int? Value, long Pos)>>
            {
                new List<(int? Value, long Pos)>()
            };

            Traverse(root, result, 0, ref numberOfProcessedNodes, ref currentPartition);


            var sb = new StringBuilder();

            for (var i = 0; i < result.Count; i++)
            {
                var partition = result[i];
                sb.Append('[');
                sb.AppendJoin(_delimiterBetweenNode, partition.OrderBy(i => i.Pos).Select(dto => dto.Value.HasValue ? dto.Value.Value.ToString() : _emptyNode));
                
                if (i + 1 == result.Count)
                    sb.Append(']');
                else
                    sb.Append($"]{_delimiterBetweenParitition}");

            }

            return sb.ToString();

            static void Traverse(TreeNode node, List<List<(int? Value, long Pos)>> result, long currentIndex, ref int numberOfProcessedNodes, ref int currentPartition)
            {
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
            int numberOfProcessedNodes = 0;
            int currentPartition = 0;

            if (string.IsNullOrWhiteSpace(data))
                return null;

            var partitions = data.Split(_delimiterBetweenParitition);

            var source = partitions[0].Split(_delimiterBetweenParitition);

            var root = new TreeNode(int.Parse(source[0]));

            Traverse(root, partitions, 0, ref numberOfProcessedNodes, ref currentPartition);

            return root;

            static void Traverse(TreeNode node, string[] partitions, long currentIndex, string[] source, ref int numberOfProcessedNodes, ref int currentPartition)
            {
                numberOfProcessedNodes++;

                if (numberOfProcessedNodes == _numberOfNodesToMakePartition)
                {
                    currentPartition++;
                    currentIndex = 0;
                    numberOfProcessedNodes = 0;
                    source = partitions[currentPartition].Split(_delimiterBetweenNode);
                }
                    source = partitions;

                if (node == null) 
                    return;


                var leftNodePos = (currentIndex * 2) + 1;
                var rightNodePos = (currentIndex * 2) + 2;

                if (leftNodePos < partitions.Length && partitions[leftNodePos] != null && int.TryParse(partitions[leftNodePos], out var val1))
                {
                    node.left = new TreeNode(val1);
                    Traverse(node.left, partitions, leftNodePos);
                }

                if (rightNodePos < partitions.Length && partitions[rightNodePos] != null && int.TryParse(partitions[rightNodePos], out var val2))
                {
                    node.right = new TreeNode(val2);
                    Traverse(node.right, partitions, rightNodePos);
                }
            }
        }

        /*
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
         */
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}