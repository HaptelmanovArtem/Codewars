using System.Text;
using System.Xml.Linq;

namespace General
{
    /// <summary>
    /// https://leetcode.com/problems/serialize-and-deserialize-binary-tree/description/
    /// </summary>
    public class SerializeAndDeserializeBinaryTree
    {
        private static readonly char _delimiter = ',';
        private static  readonly string _emptyNode = "null";

        public string Serialize(TreeNode root)
        {
            if (root == null)
                return string.Empty;

            var result = new StringBuilder();
            result.Append($"{root.val}{_delimiter}");

            GetNextLevelNodesValue(root, result);

            return result.ToString().TrimEnd(_delimiter);

            void GetNextLevelNodesValue(TreeNode node, StringBuilder sb)
            {
                var leftNodeValue = node.left is null ? _emptyNode : node.left.val.ToString();
                var rightNodeValue = node.right is null ? _emptyNode : node.right.val.ToString();

                sb.Append($"{leftNodeValue}{_delimiter}");
                sb.Append($"{rightNodeValue}{_delimiter}");

                if (node.left != null)
                {
                    GetNextLevelNodesValue(node.left, sb);
                }

                if (node.right != null)
                {
                    GetNextLevelNodesValue(node.right, sb);
                }
            }
        }

        public TreeNode Deserialize(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return null;

            TreeNode root = null;
            var source = data.Split(_delimiter);
            var currentNodeIndex = 0;

            if (source.Length == 0)
                return null;

            root = new TreeNode(int.Parse(source[currentNodeIndex]));
            var leftNodeOffset = 1;
            var rightNodeOffset = 2;

            if (leftNodeOffset < source.Length)
            {
                if (source[leftNodeOffset] != _emptyNode)
                {
                    var nodeValue = int.Parse(source[leftNodeOffset]);
                    root.left = new TreeNode(nodeValue);
                    Traverse(root.left, source, currentIndex: leftNodeOffset, leftNodeOffset + 1, rightNodeOffset + 1);
                }
            }

            Traverse(root, source, 0, leftNodeOffset, rightNodeOffset);

            return root;

            static void Traverse(TreeNode node, string[] source, int currentIndex, int leftNodeOffset, int rightNodeOffset)
            {
                if (node == null) 
                    return;

                var lnOffset = currentIndex + leftNodeOffset;
                if (lnOffset < source.Length) 
                {
                    if (source[lnOffset] != _emptyNode)
                    {
                        var nodeValue = int.Parse(source[lnOffset]);
                        node.left = new TreeNode(nodeValue);
                    }
                }

                var rnOffset = currentIndex + rightNodeOffset;
                if (rnOffset < source.Length)
                {
                    if (source[rnOffset] != _emptyNode)
                    {
                        var nodeValue = int.Parse(source[rnOffset]);
                        node.right = new TreeNode(nodeValue);
                    }
                }

                Traverse(node.left, source, lnOffset, leftNodeOffset + 1, rightNodeOffset + 2);
                Traverse(node.right, source, rnOffset, leftNodeOffset + 1, rightNodeOffset + 1);
            }
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}