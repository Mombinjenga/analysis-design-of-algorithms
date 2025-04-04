using System;

public class BinomialHeapNode
{
    public int Key;
    public BinomialHeapNode Parent;
    public BinomialHeapNode Child;
    public BinomialHeapNode Sibling;
    public int Degree;

    public BinomialHeapNode(int key)
    {
        Key = key;
        Parent = null;
        Child = null;
        Sibling = null;
        Degree = 0;
    }
}

public class BinomialHeap
{
    private BinomialHeapNode head;

    public BinomialHeap()
    {
        head = null;
    }

    public void Insert(int key)
    {
        BinomialHeapNode newNode = new BinomialHeapNode(key);
        BinomialHeap heap = new BinomialHeap();
        heap.head = newNode;
        head = Union(head, heap.head);
    }

    private BinomialHeapNode Union(BinomialHeapNode h1, BinomialHeapNode h2)
    {
        BinomialHeapNode newHead = Merge(h1, h2);
        if (newHead == null)
            return null;

        BinomialHeapNode prev = null;
        BinomialHeapNode curr = newHead;
        BinomialHeapNode next = curr.Sibling;

        while (next != null)
        {
            if (curr.Degree != next.Degree || (next.Sibling != null && next.Sibling.Degree == curr.Degree))
            {
                prev = curr;
                curr = next;
            }
            else
            {
                if (curr.Key <= next.Key)
                {
                    curr.Sibling = next.Sibling;
                    Link(next, curr);
                }
                else
                {
                    if (prev == null)
                        newHead = next;
                    else
                        prev.Sibling = next;
                    Link(curr, next);
                    curr = next;
                }
            }
            next = curr.Sibling;
        }

        return newHead;
    }

    private void Link(BinomialHeapNode y, BinomialHeapNode z)
    {
        y.Parent = z;
        y.Sibling = z.Child;
        z.Child = y;
        z.Degree++;
    }

    private BinomialHeapNode Merge(BinomialHeapNode h1, BinomialHeapNode h2)
    {
        if (h1 == null)
            return h2;
        if (h2 == null)
            return h1;

        BinomialHeapNode newHead;
        if (h1.Degree <= h2.Degree)
        {
            newHead = h1;
            h1 = h1.Sibling;
        }
        else
        {
            newHead = h2;
            h2 = h2.Sibling;
        }

        BinomialHeapNode current = newHead;

        while (h1 != null && h2 != null)
        {
            if (h1.Degree <= h2.Degree)
            {
                current.Sibling = h1;
                h1 = h1.Sibling;
            }
            else
            {
                current.Sibling = h2;
                h2 = h2.Sibling;
            }
            current = current.Sibling;
        }

        if (h1 != null)
        {
            current.Sibling = h1;
        }
        else
        {
            current.Sibling = h2;
        }

        return newHead;
    }

    public void Print()
    {
        Print(head);
        Console.WriteLine();
    }

    private void Print(BinomialHeapNode node)
    {
        while (node != null)
        {
            Console.Write(node.Key + " ");
            if (node.Child != null)
            {
                Print(node.Child);
            }
            node = node.Sibling;
        }
    }
}

public class Program
{
    public static void Main()
    {
        BinomialHeap heap = new BinomialHeap();
        heap.Insert(10);
        heap.Insert(20);
        heap.Insert(5);
        heap.Insert(7);
        heap.Insert(3);

        Console.WriteLine("Binomial heap contents:");
        heap.Print();
    }
}