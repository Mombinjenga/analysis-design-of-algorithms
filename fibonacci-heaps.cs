csharp
using System;
using System.Collections.Generic;

public class FibonacciHeapNode
{
    public int Key;
    public int Degree;
    public bool Mark;
    public FibonacciHeapNode Parent;
    public FibonacciHeapNode Child;
    public FibonacciHeapNode Left;
    public FibonacciHeapNode Right;

    public FibonacciHeapNode(int key)
    {
        Key = key;
        Degree = 0;
        Mark = false;
        Parent = null;
        Child = null;
        Left = this;
        Right = this;
    }
}

public class FibonacciHeap
{
    private FibonacciHeapNode minNode;
    private int nodeCount;

    public FibonacciHeap()
    {
        minNode = null;
        nodeCount = 0;
    }

    public void Insert(int key)
    {
        FibonacciHeapNode newNode = new FibonacciHeapNode(key);
        if (minNode == null)
        {
            minNode = newNode;
        }
        else
        {
            minNode.Left.Right = newNode;
            newNode.Left = minNode.Left;
            newNode.Right = minNode;
            minNode.Left = newNode;
            if (newNode.Key < minNode.Key)
            {
                minNode = newNode;
            }
        }
        nodeCount++;
    }

    public int ExtractMin()
    {
        FibonacciHeapNode min = minNode;
        if (min != null)
        {
            if (min.Child != null)
            {
                FibonacciHeapNode child = min.Child;
                do
                {
                    child.Parent = null;
                    child = child.Right;
                } while (child != min.Child);
            }

            min.Left.Right = min.Right;
            min.Right.Left = min.Left;

            if (min == min.Right)
            {
                minNode = null;
            }
            else
            {
                minNode = min.Right;
                Consolidate();
            }
            nodeCount--;
        }
        return min.Key;
    }

    private void Consolidate()
    {
        int arraySize = ((int)Math.Floor(Math.Log(nodeCount) / Math.Log(2))) + 1;
        List<FibonacciHeapNode> array = new List<FibonacciHeapNode>(new FibonacciHeapNode[arraySize]);

        List<FibonacciHeapNode> rootList = new List<FibonacciHeapNode>();
        FibonacciHeapNode current = minNode;
        do
        {
            rootList.Add(current);
            current = current.Right;
        } while (current != minNode);

        foreach (var w in rootList)
        {
            FibonacciHeapNode x = w;
            int d = x.Degree;
            while (array[d] != null)
            {
                FibonacciHeapNode y = array[d];
                if (x.Key > y.Key)
                {
                    var temp = x;
                    x = y;
                    y = temp;
                }
                Link(y, x);
                array[d] = null;
                d++;
            }
            array[d] = x;
        }

        minNode = null;
        foreach (var node in array)
        {
            if (node != null)
            {
                if (minNode == null)
                {
                    minNode = node;
                }
                else
                {
                    node.Left.Right = node.Right;
                    node.Right.Left = node.Left;

                    node.Left = minNode;
                    node.Right = minNode.Right;
                    minNode.Right = node;
                    node.Right.Left = node;

                    if (node.Key < minNode.Key)
                    {
                        minNode = node;
                    }
                }
            }
        }
    }

    private void Link(FibonacciHeapNode y, FibonacciHeapNode x)
    {
        y.Left.Right = y.Right;
        y.Right.Left = y.Left;
        y.Parent = x;

        if (x.Child == null)
        {
            x.Child = y;
            y.Right = y;
            y.Left = y;
        }
        else
        {
            y.Left = x.Child;
            y.Right = x.Child.Right;
            x.Child.Right = y;
            y.Right.Left = y;
        }
        x.Degree++;
        y.Mark = false;
    }

    public void Print()
    {
        Print(minNode);
        Console.WriteLine();
    }

    private void Print(FibonacciHeapNode node)
    {
        if (node == null) return;
        FibonacciHeapNode current = node;
        do
        {
            Console.Write(current.Key + " ");
            if (current.Child != null)
            {
                Print(current.Child);
            }
            current = current.Right;
        } while (current != node);
    }
}

public class Program
{
    public static void Main()
    {
        FibonacciHeap heap = new FibonacciHeap();
        heap.Insert(10);
        heap.Insert(20);
        heap.Insert(5);
        heap.Insert(7);
        heap.Insert(3);

        Console.WriteLine("Fibonacci heap contents:");
        heap.Print();

        Console.WriteLine($"Extracted min: {heap.ExtractMin()}");

        Console.WriteLine("Fibonacci heap contents after extracting min:");
        heap.Print();
    }
}