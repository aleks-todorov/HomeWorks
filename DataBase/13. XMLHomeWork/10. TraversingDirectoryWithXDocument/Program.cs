using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


class Program
{
    /*  10. Rewrite the last exercises using XDocument, XElement and XAttribute.*/

    static void Main(string[] args)
    {
        var startPath = @"C:\Windows";

        string fileName = "../../directories.xml";
        Encoding encoding = Encoding.GetEncoding("windows-1251");
        using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
        {
            writer.Formatting = Formatting.Indented;
            writer.IndentChar = '\t';
            writer.Indentation = 1;
            writer.WriteStartDocument();
            writer.WriteStartElement("directories");
            TreverseDirectories(writer, new DirectoryInfo(startPath));
            writer.WriteEndElement();
        }
    }

    private static void TreverseDirectories(XmlTextWriter writer, DirectoryInfo dir)
    {
        var folders = dir.GetDirectories();
        var files = dir.GetFiles();
        writer.WriteStartElement("folder");
        writer.WriteElementString("name", dir.Name);

        try
        {
            if (files.Count() > 0)
            {
                writer.WriteStartElement("files");
                foreach (var file in files)
                {
                    writer.WriteElementString("name", file.Name);
                }

                writer.WriteEndElement();
            }

            foreach (var child in folders)
            {
                TreverseDirectories(writer, child);
            }

            writer.WriteEndElement();
        }
        catch (Exception)
        {
            Console.WriteLine("Access denied! ");
        }
    }
}
