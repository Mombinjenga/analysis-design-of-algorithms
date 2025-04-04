using System;
using System.Collections.Generic;

public class AhoCorasickStringMatcher
{
    private class Node
    {
        public Dictionary<char, Node> Children = new Dictionary<char, Node>();
        public Node FailLink;
        public List<int> Output = new List<int>();
    }

    private Node root;

    public AhoCorasickStringMatcher()
    {
        root = new Node();
    }

    public void BuildTrie(string[] patterns)
    {
        for (int i = 0; i < patterns.Length; i++)
        {
            string pattern = patterns[i];
            Node current = root;
            foreach (char ch in pattern)
            {
                if (!current.Children.ContainsKey(ch))
                    current.Children[ch] = new Node();
                current = current.Children[ch];
            }
            current.Output.Add(i);
        }
    }

    public void BuildFailureLinks()
    {
        Queue<Node> queue = new Queue<Node>();
        foreach (var pair in root.Children)
        {
            pair.Value.FailLink = root;
            queue.Enqueue(pair.Value);
        }

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            foreach (var pair in current.Children)
            {
                char ch = pair.Key;
                Node child = pair.Value;

                Node fail = current.FailLink;
                while (fail != null && !fail.Children.ContainsKey(ch))
                {
                    fail = fail.FailLink;
                }

                if (fail == null)
                {
                    child.FailLink = root;
                }
                else
                {
                    child.FailLink = fail.Children[ch];
                    child.Output.AddRange(child.FailLink.Output);
                }

                queue.Enqueue(child);
            }
        }
    }

    public void Search(string text, string[] patterns)
    {
        Node current = root;
        for (int i = 0; i < text.Length; i++)
        {
            char ch = text[i];
            while (current != null && !current.Children.ContainsKey(ch))
            {
                current = current.FailLink;
            }
            if (current == null)
            {
                current = root;
                continue;
            }
            current = current.Children[ch];
            foreach (int index in current.Output)
            {
                Console.WriteLine("Pattern found at index " + (i - patterns[index].Length + 1) + " for pattern " + patterns[index]);
            }
        }
    }

    public static void Main()
    {
        string[] patterns = { "AB", "BCA", "CAB" };
        string text = "ABCABCABCAB";

        AhoCorasickStringMatcher matcher = new AhoCorasickStringMatcher();
        matcher.BuildTrie(patterns);
        matcher.BuildFailureLinks();
        matcher.Search(text, patterns);
    }
}
