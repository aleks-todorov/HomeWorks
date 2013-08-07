using System;
using System.Linq;
using System.Xml.Linq;

class Program
{
    /* 06. Rewrite the same using XDocument and LINQ query.*/

    static void Main(string[] args)
    {
        XDocument xmlDoc = XDocument.Load("../../catalog.xml");
        var albums =
            from album in xmlDoc.Descendants("album")
            from song in album.Descendants("songs")
            select new
            {
                Title = song.Element("title").Value
            };

        foreach (var album in albums)
        {
            Console.WriteLine(album.Title);
        }
    }
}

