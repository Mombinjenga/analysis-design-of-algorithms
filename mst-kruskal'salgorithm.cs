csharp
using System;
using System.Collections.Generic;

public class Graph
{
    private int V;
    private List<Tuple<int, int, int>> edges;

    public Graph(int v)
    {
        V = v;
        edges = new List<Tuple<int, int, int>>();
    }

    public void AddEdge(int u, int v, int w)
    {
        edges.Add(new Tuple<int, int, int>(w, u, v));
    }

    private int Find(int[] parent, int i)
    {
        if (parent[i] == i)
            return i;
        return Find(parent, parent[i]);
    }

    private void Union(int[] parent, int[] rank, int x, int y)
    {
        int xroot = Find(parent, x);
        int yroot = Find(parent, y);

        if (rank[xroot] < rank[yroot])
            parent[xroot] = yroot;
        else if (rank[xroot] > rank[yroot])
            parent[yroot] = xroot;
        else
        {
            parent[yroot] = xroot;
            rank[xroot]++;
        }
    }

    public void KruskalMST()
    {
        List<Tuple<int, int, int>> result = new List<Tuple<int, int, int>>();
        edges.Sort((a, b) => a.Item1.CompareTo(b.Item1));

        int[] parent = new int[V];
        int[] rank = new int[V];

        for (int v = 0; v < V; v++)
        {
            parent[v] = v;
            rank[v] = 0;
        }

        int e = 0;
        int i = 0;

        while (e < V - 1)
        {
            Tuple<int, int, int> nextEdge = edges[i++];
            int x = Find(parent, nextEdge.Item2);
            int y = Find(parent, nextEdge.Item3);

            if (x != y)
            {
                result.Add(nextEdge);
                Union(parent, rank, x, y);
                e++;
            }
        }

        Console.WriteLine("Following are the edges in the constructed MST:");
        foreach (var edge in result)
        {
            Console.WriteLine($"{edge.Item2} -- {edge.Item3} == {edge.Item1}");
        }
    }

    public static void Main()
    {
        Graph g = new Graph(4);
        g.AddEdge(0, 1, 10);
        g.AddEdge(0, 2, 6);
        g.AddEdge(0, 3, 5);
        g.AddEdge(1, 3, 15);
        g.AddEdge(2, 3, 4);

        g.KruskalMST();
    }
}