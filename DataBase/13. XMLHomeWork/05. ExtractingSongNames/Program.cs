using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


class Program
{
    /* 05. Write a program, which using XmlReader extracts all song titles from catalog.xml.*/

    static void Main(string[] args)
    {
        using (XmlReader reader = XmlReader.Create("../../catalog.xml"))
        {
            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) &&
                    (reader.Name == "title"))
                {
                    Console.WriteLine(reader.ReadElementString());
                }
            }
        }
    }
}
