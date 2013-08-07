using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


class Program
{
    /* 9. Write a program to traverse given directory and write to a XML file its contents together 
     * with all subdirectories and files. Use tags <file> and <dir> with appropriate attributes.
     * For the generation of the XML document use the class XmlWriter.*/

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
