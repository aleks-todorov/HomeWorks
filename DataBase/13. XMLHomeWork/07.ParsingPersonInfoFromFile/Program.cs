using System;
using System.IO;
using System.Xml.Linq;

class Program
{
    /* 07. In a text file we are given the name, 
     * address and phone number of given person 
     * (each at a single line). Write a program, 
     * which creates new XML document, which contains
     * these data in structured XML format.*/

    static void Main(string[] args)
    {
        var filePath = "../../Info.txt";
        var reader = new StreamReader(filePath);
        XElement personXML = new XElement("people");

        using (reader)
        {
            var line = reader.ReadLine();

            while (line != null)
            {
                var name = line;
                line = reader.ReadLine();
                var address = line;
                line = reader.ReadLine();
                var phone = line;
                line = reader.ReadLine();

                personXML.Add(new XElement("person",
                    new XElement("name", name),
                    new XElement("address", address),
                    new XElement("phoneNumber", phone)));
            }
        }

        Console.WriteLine(personXML);

        personXML.Save("../../person.xml");
    }
}

