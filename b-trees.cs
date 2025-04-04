using System;
using System.Collections.Generic;

public class BTreeNode
{
    public int[] Keys;
    public int Degree;
    public BTreeNode[] Children;
    public int KeyCount;
    public bool IsLeaf;

    public BTreeNode(int degree, bool isLeaf)
    {
        Degree = degree;
        IsLeaf = isLeaf;
        Keys = new int[2 * degree - 1];
        Children = new BTreeNode[2 * degree];
        KeyCount = 0;
    }
}

public class BTree
{
    private BTreeNode root;
    private int degree;

    public BTree(int degree)
    {
        this.degree = degree;
        root = null;
    }

    public void Insert(int key)
    {
        if (root == null)
        {
            root = new BTreeNode(degree, true);
            root.Keys[0] = key;
            root.KeyCount = 1;
        }
        else
        {
            if (root.KeyCount == 2 * degree - 1)
            {
                BTreeNode newRoot = new BTreeNode(degree, false);
                newRoot.Children[0] = root;
                SplitChild(newRoot, 0, root);
                int i = 0;
                if (newRoot.Keys[0] < key)
                    i++;
                InsertNonFull(newRoot.Children[i], key);
                root = newRoot;
            }
            else
            {
                InsertNonFull(root, key);
            }
        }
    }

    private void InsertNonFull(BTreeNode node, int key)
    {
        int i = node.KeyCount - 1;
        if (node.IsLeaf)
        {
            while (i >= 0 && node.Keys[i] > key)
            {
                node.Keys[i + 1] = node.Keys[i];
                i--;
            }
            node.Keys[i + 1] = key;
            node.KeyCount++;
        }
        else
        {
            while (i >= 0 && node.Keys[i] > key)
                i--;
            if (node.Children[i + 1].KeyCount == 2 * degree - 1)
            {
                SplitChild(node, i + 1, node.Children[i + 1]);
                if (node.Keys[i + 1] < key)
                    i++;
            }
            InsertNonFull(node.Children[i + 1], key);
        }
    }

    private void SplitChild(BTreeNode parent, int index, BTreeNode node)
    {
        BTreeNode newNode = new BTreeNode(degree, node.IsLeaf);
        newNode.KeyCount = degree - 1;
        for (int j = 0; j < degree - 1; j++)
            newNode.Keys[j] = node.Keys[j + degree];
        if (!node.IsLeaf)
        {
            for (int j = 0; j < degree; j++)
                newNode.Children[j] = node.Children[j + degree];
        }
        node.KeyCount = degree - 1;
        for (int j = parent.KeyCount; j >= index + 1; j--)
            parent.Children[j + 1] = parent.Children[j];
        parent.Children[index + 1] = newNode;
        for (int j = parent.KeyCount - 1; j >= index; j--)
            parent.Keys[j + 1] = parent.Keys[j];
        parent.Keys[index] = node.Keys[degree - 1];
        parent.KeyCount++;
    }

    public void Traverse()
    {
        if (root != null)
            Traverse(root);
    }

    private void Traverse(BTreeNode node)
    {
        int i;
        for (i = 0; i < node.KeyCount; i++)
        {
            if (!node.IsLeaf)
                Traverse(node.Children[i]);
            Console.Write(node.Keys[i] + " ");
        }
        if (!node.IsLeaf)
            Traverse(node.Children[i]);
    }
}

public class Program
{
    public static void Main()
    {
        BTree bTree = new BTree(3);
        bTree.Insert(10);
        bTree.Insert(20);
        bTree.Insert(5);
        bTree.Insert(6);
        bTree.Insert(12);
        bTree.Insert(30);
        bTree.Insert(7);
        bTree.Insert(17);

        Console.WriteLine("Traversal of the constructed B-tree is:");
        bTree.Traverse();
    }
}
