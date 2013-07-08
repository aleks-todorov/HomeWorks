using System;
using System.Collections.Generic;

//100 points
class Application
{
    static long maxSum = 0;
    static HashSet<Node> usedNodes = new HashSet<Node>();

    static void Main(string[] args)
    {
        var N = int.Parse(Console.ReadLine());
        var nodes = new Dictionary<int, Node>();
        int maxNode = 0;

        for (int i = 0; i < N - 1; i++)
        {
            string connection = Console.ReadLine();
            string[] separatedConnection = connection.Split(new char[] { '(', '<', '-', ')' }, StringSplitOptions.RemoveEmptyEntries);
            int parent = int.Parse(separatedConnection[0]);
            int child = int.Parse(separatedConnection[1]);

            Node parentNode;
            Node childNode;

            if (nodes.ContainsKey(parent))
            {
                parentNode = nodes[parent];
            }
            else
            {
                parentNode = new Node(parent);
                nodes.Add(parent, parentNode);
            }

            if (nodes.ContainsKey(child))
            {
                childNode = nodes[child];
            }
            else
            {
                childNode = new Node(child);
                nodes.Add(child, childNode);
            }

            parentNode.AddChild(childNode);
            childNode.AddChild(parentNode);

        }

        foreach (var node in nodes)
        {
            if (node.Value.Count() == 1)
            {
                usedNodes.Clear();
                DFS(node.Value, 0);
            }
        }

        Console.WriteLine(maxSum);
    }

    static void DFS(Node node, long currentSum)
    {
        currentSum += node.Value;
        usedNodes.Add(node);
        for (int i = 0; i < node.Count(); i++)
        {
            if (usedNodes.Contains(node.GetChild(i)))
            {
                continue;
            }

            DFS(node.GetChild(i), currentSum);
        }

        if (node.Count() == 1 && currentSum > maxSum)
        {
            maxSum = currentSum;
        }
    }
}

public class Node
{
    public int Value { get; set; }
    public List<Node> Children { get; set; }
    public bool HasParrent { get; set; }
    private int counter = 0;

    public Node(int value)
    {
        this.Value = value;
        this.Children = new List<Node>();
        this.HasParrent = false;
    }

    public void AddChild(Node child)
    {
        child.HasParrent = true;
        Children.Add(child);
        this.counter++;
    }

    public int Count()
    {
        return counter;
    }

    public Node GetChild(int index)
    {
        return Children[index];
    }
}

