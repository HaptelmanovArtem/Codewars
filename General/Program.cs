using General;

Console.WriteLine("Run1");

var serializer = new SerializeAndDeserializeBinaryTree();

var root = new TreeNode(1);
var leftLeaf1 = new TreeNode(2);
var rightLeaf1 = new TreeNode(3);
root.left = leftLeaf1;
root.right = rightLeaf1;

var leftLeftLeaf12 = new TreeNode(4);
var leftRightLeaf12 = new TreeNode(5);
leftLeaf1.left = leftLeftLeaf12;
leftLeaf1.right = leftRightLeaf12;

var leftLeftLeaf22 = new TreeNode(8);
var leftRightLeaf22 = new TreeNode(64);
leftLeftLeaf12.left = leftLeftLeaf22;
leftLeftLeaf12.right = leftRightLeaf22;

var rightLeftLeaf22 = new TreeNode(10);
var rightRightLeaf22 = new TreeNode(100);
leftRightLeaf12.left = rightLeftLeaf22;
leftRightLeaf12.right = rightRightLeaf22;

var serilizedData = serializer.Serialize(root);
var deserializedData = serializer.Deserialize(serilizedData);

return;
