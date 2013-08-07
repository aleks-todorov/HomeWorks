using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

class ExtractingInformationWithExpath
{
    static void Main(string[] args)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("../../catalog.xml");
        string xPathQuery = "/catalog/album";

        XmlNodeList albums = xmlDoc.SelectNodes(xPathQuery);

        var listOfAlbums = new Dictionary<string, List<string>>();

        foreach (XmlNode album in albums)
        {
            var artist = album.SelectSingleNode("artist").InnerText;
            var albumName = album.SelectSingleNode("name").InnerText;

            if (listOfAlbums.ContainsKey(artist))
            {
                listOfAlbums[artist].Add(albumName);
            }
            else
            {
                listOfAlbums.Add(artist, new List<string>() { albumName });
            }
        }

        foreach (var album in listOfAlbums)
        {
            Console.WriteLine("Artist: {0}", album.Key);
            Console.WriteLine("Number of albums {0}", album.Value.Count());
        }
    }
}

