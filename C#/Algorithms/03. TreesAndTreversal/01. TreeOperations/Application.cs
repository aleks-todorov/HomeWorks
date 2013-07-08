using System;
using System.Collections.Generic;

class Application
{
    /* Task 1:
     * You are given a tree of N nodes represented as a set of N-1 pairs of nodes (parent node, child node), 
     * each in the range (0..N-1).  
     * Write a program to read the tree and find:
     * a. the root node
     * b. all leaf nodes
     * c. all middle nodes
     * d. the longest path in the tree
     * e*. all paths in the tree with given sum S of their nodes
     * f*. all subtrees with given sum S of their nodes 
     */

    static HashSet<Node> visitedNodes = new HashSet<Node>();
    static int longestPath = 0;

    static void Main(string[] args)
    {
        var N = int.Parse(Console.ReadLine());
        var nodes = new Dictionary<int, Node>();

        for (int i = 0; i < N - 1; i++)
        {
            var input = Console.ReadLine();
            string[] nodeInfo = input.Split(' ');
            var parent = int.Parse(nodeInfo[0]);
            var child = int.Parse(nodeInfo[1]);

            Node parentNode;
            Node childNode;

            if (nodes.ContainsKey(parent))
            {
                parentNode = nodes[parent];
            }
            else
            {
                parentNode = new Node(parent);
                nodes.Add(parentNode.Value, parentNode);
            }

            if (nodes.ContainsKey(child))
            {
                childNode = nodes[child];
            }
            else
            {
                childNode = new Node(child);
                nodes.Add(childNode.Value, childNode);
            }

            parentNode.Children.Add(childNode);
            childNode.Children.Add(parentNode);
            childNode.HasParent = true;
        }

        //a. Finding the root node
        var root = FindingTheRootNode(nodes);
        Console.WriteLine("The root element is: {0}", root.Value);

        //b. Finding all leafs
        FindAllLeafs(nodes);

        //c. Finding all middle nodes
        FindingAllMiddleElements(nodes);

        //d. Finding the longest path(from root to leaf) 
        var longestPath = FindLongestPath(root);
        Console.WriteLine("Longest path is: {0}", longestPath);
    }

    private static int FindLongestPath(Node node)
    {
        visitedNodes.Add(node);

        if (node.Count() == 1)
        {
            return 0;
        }

        int maxPath = 0;
        foreach (var item in node.Children)
        {
            if (visitedNodes.Contains(item))
            {
                continue;
            }

            maxPath = Math.Max(maxPath, FindLongestPath(item));
        }

        return maxPath + 1;
    }

    private static void FindingAllMiddleElements(Dictionary<int, Node> nodes)
    {
        Console.Write("Middle Nodes: ");
        foreach (var node in nodes)
        {
            if (node.Value.HasParent == true && node.Value.Count() > 1)
            {
                Console.Write("{0} ", node.Key);
            }
        }
        Console.WriteLine();
    }

    private static void FindAllLeafs(Dictionary<int, Node> nodes)
    {
        Console.Write("Leafs: ");
        foreach (var node in nodes)
        {
            //Because we are making 2 way connection for the elements, 
            //those who have only 1 child are leafs, e.g they do not have any childres, only parents.
            if (node.Value.Count() == 1)
            {
                Console.Write("{0} ", node.Key);
            }
        }
        Console.WriteLine();
    }

    private static Node FindingTheRootNode(Dictionary<int, Node> nodes)
    {
        foreach (var node in nodes)
        {
            if (node.Value.HasParent == false)
            {
                return node.Value;
            }
        }

        throw new ArgumentException("Invalid input data. This tree does not have root!");
    }
}

