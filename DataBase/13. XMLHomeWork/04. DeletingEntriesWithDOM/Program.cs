using System;
using System.Xml;

class Program
{
    /* 04. Using the DOM parser write a program to delete from catalog.xml all albums having price > 20.*/

    static void Main(string[] args)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("../../catalog.xml");
        XmlNode rootNode = doc.DocumentElement;

        Console.WriteLine("Number of nodes is {0}", rootNode.ChildNodes.Count);

        foreach (XmlNode node in rootNode.ChildNodes)
        {
            var price = decimal.Parse(node["price"].InnerText);

            if (price > 20)
            {
                node.ParentNode.RemoveChild(node);
            }
        }

        Console.WriteLine("Number of nodes is {0}", rootNode.ChildNodes.Count);
    }
}

