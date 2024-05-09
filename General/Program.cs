using General;

Console.WriteLine("Run1");

var serializer = new SerializeAndDeserializeBinaryTree();

var root = new TreeNode(1);
TreeNode current = root;
foreach(var i in Enumerable.Range(2, 1000))
{
    current.right = new TreeNode(i);
    current = current.right;
}

var serilizedData = serializer.Serialize(root);
var deserializedData = serializer.Deserialize(serilizedData);

return;
