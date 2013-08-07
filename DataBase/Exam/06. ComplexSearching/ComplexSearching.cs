using System;
using System.Linq;
using System.Text;
using System.Xml;
using Bookstore.Models;
using Log.Models;
using Log.Data.Migrations;
using System.Data.Entity;

static class ComplexSearching
{
    static void Main(string[] args)
    {
        var dbCon = new BookstoreDbEntities();

        /*Using the context from Task 7. If performance test must be done, please comment the task 7 part. Thank you! */

        var logContext = new LogContext();
        Database.SetInitializer(new MigrateDatabaseToLatestVersion
       <LogContext, Configuration>());

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("../../reviews-queries.xml");
        string xPathQuery = "/review-queries/query";

        XmlNodeList queries = xmlDoc.SelectNodes(xPathQuery);

        string fileName = "../../reviews-search-results.xml";
        Encoding encoding = Encoding.GetEncoding("windows-1251");

        using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
        {
            writer.Formatting = Formatting.Indented;
            writer.IndentChar = '\t';
            writer.Indentation = 1;
            writer.WriteStartDocument();
            writer.WriteStartElement("search-results");

            foreach (XmlNode query in queries)
            {
                //Task 7 Call Method
                UpdateXMLToLogDB(logContext, query);

                if (query.Attributes["type"].Value == "by-period")
                {
                    var startDate = DateTime.Parse(query.GetChildText("start-date"));
                    var endDate = DateTime.Parse(query.GetChildText("end-date"));

                    if (startDate == null || endDate == null)
                    {
                        throw new ArgumentException("Stard date and end date are mendatory!");
                    }

                    if (startDate > endDate)
                    {
                        var reviews = from r in dbCon.Reviews.Include("Books")
                                      select r;

                        reviews = reviews.Where(r => r.DateOfCreation < startDate && r.DateOfCreation > endDate)
                           .OrderBy(r => r.DateOfCreation).ThenBy(r => r.Text);

                        WriteResults(writer, reviews);
                    }
                    else
                    {
                        var reviews = from r in dbCon.Reviews.Include("Books")
                                      select r;

                        reviews = reviews.Where(r => r.DateOfCreation > startDate && r.DateOfCreation < endDate)
                            .OrderBy(r => r.DateOfCreation).ThenBy(r => r.Text);

                        WriteResults(writer, reviews);
                    }
                }

                else if (query.Attributes["type"].Value == "by-author")
                {
                    var authorName = query.GetChildText("author-name");

                    if (authorName == null)
                    {
                        throw new ArgumentException("Author's Name is mendatory!");
                    }

                    var author = CreateOrLoadAuthor(dbCon, authorName);

                    var reviews = from r in dbCon.Reviews.Include("Books")
                                  select r;

                    reviews = reviews.Where(r => r.AuthorId == author.Id)
                      .OrderBy(r => r.DateOfCreation).ThenBy(r => r.Text);

                    WriteResults(writer, reviews);
                }
            }

            writer.WriteEndElement();
        }
    }

    private static void UpdateXMLToLogDB(LogContext logContext, XmlNode query)
    {
        var log = new CustomLogs();
        log.Date = DateTime.Now;
        log.QueryXML = query.OuterXml;
        logContext.Logs.Add(log);
        logContext.SaveChanges();

        //The reason why I am doing the SaveChanges here is because,
        //since some exceptions are thrown in the parsing, the processed 
        //queries might never be uploaded to the server
    }

    private static void WriteResults(XmlTextWriter writer, IQueryable<Review> reviews)
    {
        reviews.OrderBy(x => x.DateOfCreation);

        writer.WriteStartElement("result-set");
        foreach (var item in reviews)
        {
            writer.WriteStartElement("review");
            if (item.DateOfCreation != null)
            {
                writer.WriteElementString("date", item.DateOfCreation.ToString("dd-MMM-yyyy"));
            }

            writer.WriteElementString("content", item.Text);
            writer.WriteStartElement("book");

            var title = item.Books.FirstOrDefault().title;
            if (title != null)
            {
                writer.WriteElementString("title", title);
            }

            var isbn = item.Books.FirstOrDefault().ISBN;
            if (isbn != null)
            {
                writer.WriteElementString("ISBN", isbn);
            }

            var price = item.Books.FirstOrDefault().Price;
            if (price != null)
            {
                writer.WriteElementString("price", price.ToString());
            }

            var website = item.Books.FirstOrDefault().Website;
            if (price != null)
            {
                writer.WriteElementString("website", website);
            }

            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        writer.WriteEndElement();
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
}

