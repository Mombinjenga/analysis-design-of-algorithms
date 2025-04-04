using System;
public class AugmentedTreeNode
{
 public int Value;
 public int SubtreeSize;
 public AugmentedTreeNode Left;
 public AugmentedTreeNode Right;
 public AugmentedTreeNode(int value)
 {
Value = value;
 SubtreeSize = 1;
 Left = null;
 Right = null;
 }
}
public class AugmentedBinarySearchTree
{
 public AugmentedTreeNode Root;
 public void Insert(int value)
 {
 Root = InsertRec(Root, value);
 }
 private AugmentedTreeNode InsertRec(AugmentedTreeNode root, int 
value)
 {
 if (root == null)
 {
 root = new AugmentedTreeNode(value);
 return root;
 }
 if (value < root.Value)
 root.Left = InsertRec(root.Left, value);
 else if (value > root.Value)
 root.Right = InsertRec(root.Right, value);
 root.SubtreeSize = 1 + GetSize(root.Left) + 
GetSize(root.Right);
 return root;
 }
 private int GetSize(AugmentedTreeNode node)
 {
 return node == null ? 0 : node.SubtreeSize;
 }
 public void InOrderTraversal(AugmentedTreeNode node)
 {
 if (node != null)
 {
 InOrderTraversal(node.Left);
 Console.WriteLine($"Value: {node.Value}, Subtree Size: 
{node.SubtreeSize}");
 InOrderTraversal(node.Right);
 }
 }
}
public class AugmentedBinarySearchTreeExample
{
 public static void Main()
 {
 AugmentedBinarySearchTree bst = new 
AugmentedBinarySearchTree();
 bst.Insert(5);
 bst.Insert(3);
 bst.Insert(7);
 bst.Insert(2);
 bst.Insert(4);
 bst.Insert(6);
 bst.Insert(8);
 Console.WriteLine("In-order traversal with subtree sizes:");
 bst.InOrderTraversal(bst.Root);
 }
}