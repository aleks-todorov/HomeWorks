using System;
using System.Linq;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        XDocument xmlDoc = XDocument.Load("../../catalog.xml");
        var prices =
            from album in xmlDoc.Descendants("album")
            where DateTime.Now.Year - int.Parse(album.Element("year").Value) > 5
            select album.Element("price");

        foreach (XElement price in prices)
        {
            Console.WriteLine(price.Value);
        }
    }
}
