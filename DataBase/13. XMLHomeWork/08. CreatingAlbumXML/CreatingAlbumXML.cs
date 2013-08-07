using System.Text;
using System.Xml;

class Program
{
    /* 08. Write a program, which (using XmlReader and XmlWriter) reads the file catalog.xml 
     * and creates the file album.xml, in which stores in appropriate way 
     * the names of all albums and their authors.*/

    static void Main(string[] args)
    {
        using (XmlReader reader = XmlReader.Create("../../catalog.xml"))
        {
            string fileName = "../../albums.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("albums");
                var title = string.Empty;
                var artist = string.Empty;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "name")
                        {
                            title = reader.ReadElementString();
                        }
                        else if (reader.Name == "artist")
                        {
                            artist = reader.ReadElementString();
                            WriteAlbum(writer, title, artist);
                        }
                    }
                }
            }
        }
    }

    private static void WriteAlbum(XmlWriter writer, string title, string artist)
    {
        writer.WriteStartElement("album");
        writer.WriteElementString("title", title);
        writer.WriteElementString("author", artist);
        writer.WriteEndElement();
    }
}

