using System;
using System.Linq;
using System.Xml;
using Bookstore.Models;
using System.Data.Entity;
using Log.Data.Migrations;
using Log.Models;

static class SimpleSearchForBooks
{
    /*Task 5*/

    static void Main(string[] args)
    {
        /*Using the context from Task 7*/

        var logContext = new LogContext();
        Database.SetInitializer(new MigrateDatabaseToLatestVersion
       <LogContext, Configuration>());

        var dbCon = new BookstoreDbEntities();

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("../../simple-query.xml");

        string title = null;
        string author = null;
        string isbn = null;

        XmlNodeList queries = xmlDoc.SelectNodes("/query");

        foreach (XmlNode query in queries)
        {
            title = query.GetChildText("title");
            author = query.GetChildText("author");
            isbn = query.GetChildText("isbn");

            //Update the query XML to the log DB. May slow things a little bit... 
            // var log = new CustomLogs();
            // log.Date = DateTime.Now;
            // log.QueryXML = query.OuterXml;
            // logContext.Logs.Add(log);
            // logContext.SaveChanges();
        }


        var booksQuery =
                from b in dbCon.Books.Include("Authors")
                select b;

        if (title != null)
        {
            booksQuery =
                from b in dbCon.Books
                where b.title.ToLower() == title.ToLower()
                select b;
        }

        if (author != null)
        {
            booksQuery = booksQuery.Where(
                b => b.Authors.Any(t => t.Name.ToLower() == author.ToLower()));
        }
        if (isbn != null)
        {
            booksQuery = booksQuery.Where(
                b => b.ISBN == isbn);
        }
        booksQuery = booksQuery.OrderBy(b => b.title);

        if (booksQuery.Count() == 0)
        {
            Console.WriteLine("Nothing Found");
        }
        else
        {
            foreach (var item in booksQuery)
            {
                string reviews = string.Empty;
                if (item.Reviews.Count() > 1)
                {
                    reviews = item.Reviews.Count() + " review";
                }

                else if (item.Reviews.Count() > 2)
                {
                    reviews = item.Reviews.Count() + " reviews";
                }

                else
                {
                    reviews = " no reviews";
                }

                Console.WriteLine(item.title + "--> " + reviews);
            }
        }
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

