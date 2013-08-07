using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

/*02. Write program that extracts all different artists which are found in 
 * the catalog.xml. For each author you should print the number of albums in the catalogue. 
 * Use the DOM parser and a hash-table.*/

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<string>> albums = new Dictionary<string, List<string>>();
        XmlDocument doc = new XmlDocument();
        doc.Load("../../catalog.xml");

        XmlNode rootNode = doc.DocumentElement;

        foreach (XmlNode node in rootNode.ChildNodes)
        {
            var artist = node["artist"].InnerText;
            var albumName = node["name"].InnerText;

            if (albums.ContainsKey(artist))
            {
                albums[artist].Add(albumName);
            }
            else
            {
                albums.Add(artist, new List<string>() { albumName });
            }
        }

        foreach (var album in albums)
        {
            Console.WriteLine("Artist: {0}", album.Key);
            Console.WriteLine("Number of albums {0}", album.Value.Count());
        }
    }
}

