using System;
using System.Linq;
using System.Xml;
using Bookstore.Models;

static class SimpleXMLImporter
{
    /*Task 3: */

    //Note: Please note that the connection strings must be corrected for each task. Thank you ! 

    static void Main(string[] args)
    {
        var dbCon = new BookstoreDbEntities();

        using (dbCon)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../simple-books.xml");
            string xPathQuery = "/catalog/book";

            XmlNodeList books = xmlDoc.SelectNodes(xPathQuery);

            //Reading the XML with XPath
            foreach (XmlNode book in books)
            {
                var bookEntry = new Book();
                bookEntry.title = book.GetChildText("title");
                if (bookEntry.title == null)
                {
                    throw new ArgumentException("Provided book does not have an title!");
                }

                var authors = book.SelectNodes("author");

                if (authors.Count == 0)
                {
                    throw new ArgumentException("Provided book does not have an author(s)!");
                }

                //Making sure that all the authors are processed.
                foreach (XmlNode author in authors)
                {
                    var name = author.InnerText;
                    bookEntry.Authors.Add(CreateOrLoadAuthor(dbCon, name));
                }

                var price = book.GetChildText("price");
                if (price != null)
                {
                    bookEntry.Price = decimal.Parse(price);
                }
                else
                {
                    bookEntry.Price = null;
                }

                var webSite = book.GetChildText("web-site");
                if (webSite != null)
                {
                    bookEntry.Website = book.GetChildText("web-site");
                }

                var isbn = book.GetChildText("isbn");

                if (isbn != null)
                {
                    bookEntry.ISBN = book.GetChildText("isbn");
                }

                dbCon.Books.Add(bookEntry);
            }

            dbCon.SaveChanges();
        }
    }

    private static Author CreateOrLoadAuthor(
            BookstoreDbEntities context, string name)
    {
        Author existingAuthor =
            (from a in context.Authors
             where a.Name.ToLower() == name.ToLower()
             select a).FirstOrDefault();

        if (existingAuthor != null)
        {
            return existingAuthor;
        }

        var newAuthor = new Author();
        newAuthor.Name = name;
        context.Authors.Add(newAuthor);
        context.SaveChanges();

        return newAuthor;
    }

    private static string GetChildText(this XmlNode node, string tagName)
    {
        XmlNode childNode = node.SelectSingleNode(tagName);
        if (childNode == null)
        {
            return null;
        }
        return childNode.InnerText.Trim();
    }
}

