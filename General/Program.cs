using General;

Console.WriteLine("Run1");

var serializer = new SerializeAndDeserializeBinaryTree();

var root = new TreeNode(1);
root.left = new TreeNode(2);
root.right = new TreeNode(3);

root.right.left = new TreeNode(4);
root.right.right = new TreeNode(5);

root.right.left.left = new TreeNode(6);
root.right.left.right = new TreeNode(7);


var serilizedData = serializer.Serialize(root);
var deserializedData = serializer.Deserialize(serilizedData);

return;
