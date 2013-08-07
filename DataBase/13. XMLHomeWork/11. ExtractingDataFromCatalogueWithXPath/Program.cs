using System;
using System.Collections.Generic;
using System.Xml;

class Program
{
    /* 11. Write a program, which extract from the file catalog.xml the prices for all albums,
     * published 5 years ago or earlier. Use XPath query.*/

    static void Main(string[] args)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("../../catalog.xml");
        string xPathQuery = "/catalog/album";

        XmlNodeList albums = xmlDoc.SelectNodes(xPathQuery);

        var prices = new List<decimal>();

        foreach (XmlNode album in albums)
        {
            var year = int.Parse(album.SelectSingleNode("year").InnerText);
            var publishDate = new DateTime(year, 1, 1);
            if (DateTime.Now.Year - publishDate.Year > 5)
            {
                prices.Add(decimal.Parse(album.SelectSingleNode("price").InnerText));
            }
        }

        foreach (var price in prices)
        {
            Console.WriteLine(price);
        }
    }
}

