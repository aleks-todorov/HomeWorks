using System;
using System.Collections.Generic;

class Node
{
    public int Value { get; set; }
    public List<Node> Children { get; set; }
    public bool HasParent { get; set; }

    public Node(int value)
    {
        this.Value = value;
        this.Children = new List<Node>();
        this.HasParent = false;
    }

    public int Count()
    {
        return this.Children.Count;
    }

    public void Add(Node child)
    { 
        this.Children.Add(child);
    }

    public Node GetElement(int index)
    {
        return Children[index];
    }
}

