using System;
public class TreeNode
{
 public int Value;
 public TreeNode Left;
 public TreeNode Right;
 public TreeNode(int value)
 {
 Value = value;
 Left = null;
 Right = null;
 }
}
public class BinarySearchTree
{
 public TreeNode Root;
 public void Insert(int value)
 {
 Root = InsertRec(Root, value);
 }
 private TreeNode InsertRec(TreeNode root, int value)
 {
 if (root == null)
 {
 root = new TreeNode(value);
 return root;
 }
 if (value < root.Value)
 root.Left = InsertRec(root.Left, value);
 else if (value > root.Value)
 root.Right = InsertRec(root.Right, value);
 return root;
 }
 public void InOrderTraversal(TreeNode node)
 {
 if (node != null)
 {
 InOrderTraversal(node.Left);
 Console.WriteLine(node.Value);
 InOrderTraversal(node.Right);
 }
 }
}
public class BinarySearchTreeExample
{
 public static void Main()
 {
 BinarySearchTree bst = new BinarySearchTree();
 bst.Insert(5);
 bst.Insert(3);
 bst.Insert(7);
 bst.Insert(2);
 bst.Insert(4);
 bst.Insert(6);
 bst.Insert(8);
 Console.WriteLine("In-order traversal:");
 bst.InOrderTraversal(bst.Root);
 }
}