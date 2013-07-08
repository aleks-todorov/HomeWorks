using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<int, Node> graph = new Dictionary<int, Node>();
    static HashSet<int> visited = new HashSet<int>();
    static int counter = 0;

    static void Main(string[] args)
    {
        int v = int.Parse(Console.ReadLine());
        int e = int.Parse(Console.ReadLine());

        for (int i = 0; i < e; i++)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var vertex = int.Parse(input[0]);
            var edge = int.Parse(input[1]);

            if (!graph.ContainsKey(vertex))
            {
                graph.Add(vertex, new Node(vertex));
            }

            if (!graph.ContainsKey(edge))
            {
                graph.Add(edge, new Node(edge));
            }

            graph[vertex].Add(graph[edge]);
            graph[edge].Add(graph[vertex]);
        }

        Console.WriteLine();
        PrintGraph(graph[0], 0);
        visited.Clear();
        var foundPath = CheckForPath(graph[2], graph[6], false);
        Console.WriteLine(foundPath);
        PrintPath(foundPath);
        visited.Clear();

        foreach (var node in graph)
        {
            if (node.Value.Group == null)
            {
                SeparateInGroups(node.Value);
                counter++;
            }
        }

        Console.WriteLine(graph[0].Group == graph[10].Group);
        Console.WriteLine(graph[10].Group == graph[12].Group);
        Console.WriteLine(graph[4].Group == graph[8].Group);
        Console.WriteLine(graph[7].Group == graph[8].Group);
    }

    private static void SeparateInGroups(Node node)
    {
        if (visited.Contains(node.Value))
        {
            return;
        }

        node.Group = counter;
        visited.Add(node.Value);

        foreach (var nodes in node.Childrens)
        {
            SeparateInGroups(nodes);
        }
    }

    private static void PrintPath(bool foundPath)
    {
        if (foundPath)
        {
            foreach (var item in visited)
            {
                Console.WriteLine("{0}", item);
            }
        }
    }

    private static bool CheckForPath(Node startNode, Node endNode, bool pathFound)
    {
        if (visited.Contains(startNode.Value))
        {
            return pathFound;
        }

        if (startNode.Value == endNode.Value)
        {
            pathFound = true;
            return pathFound;
        }

        visited.Add(startNode.Value);

        foreach (var child in startNode.Childrens)
        {
            var foundPath = CheckForPath(child, endNode, pathFound);
            if (foundPath == true)
            {
                return true;
            }
        }

        return false;
    }

    private static void PrintGraph(Node node, int spaces)
    {
        if (visited.Contains(node.Value))
        {
            return;
        }

        visited.Add(node.Value);
        var tab = new string(' ', spaces);
        Console.WriteLine(tab + "{0}", node.Value);
        spaces++;
        foreach (var child in node.Childrens)
        {
            PrintGraph(child, spaces);
        }
    }
}

