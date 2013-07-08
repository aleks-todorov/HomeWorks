using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<int, Node> graph = new Dictionary<int, Node>();
    static HashSet<int> visited = new HashSet<int>();

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
        BFS(graph[5]);
    }

    private static void BFS(Node someNode)
    {
        var elements = new Queue<Node>();
        elements.Enqueue(someNode);

        while (elements.Count > 0)
        {
            var element = elements.Dequeue();

            if (visited.Contains(element.Value))
            {
                continue;
            }
            foreach (var node in element.Childrens)
            {
                elements.Enqueue(node);

            }

            visited.Add(element.Value);

            Console.WriteLine(element.Value);
        }
    }
}

