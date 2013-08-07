﻿using System.Collections.Generic;
 
public class Node  
{
    public int Value { get; set; }
    public List<Node> Childrens { get; set; }

    public Node(int value)
    {
        this.Value = value;
        this.Childrens = new List<Node>();
    }

    public int Count()
    {
        return this.Childrens.Count;
    }

    public void Add(Node child)
    {
        this.Childrens.Add(child);
    }

}
