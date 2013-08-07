using System;
using System.Linq;
using System.Xml;
using Bookstore.Models;
using System.Transactions;

static class ComplexXMLImporter
{
    /*Task 4*/

    static void Main(string[] args)
    {
        //As Nakov told us book ISBN should not be unique, thus, same books can be added. It's not a bug, its a feature :) 
        var dbCon = new BookstoreDbEntities();

        using (dbCon)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../complex-books.xml");
            string xPathQuery = "/catalog/book";

            XmlNodeList books = xmlDoc.SelectNodes(xPathQuery);

            //Reading the XML with XPath
            foreach (XmlNode book in books)
            {
                //Processing each query in different transaction, so we can be sure that if one fails, the correct ones will be processed. 
                //There should be an easier way, but for now this works as well :) 
                var tran = new TransactionScope();

                using (tran)
                {
                    try
                    {
                        var bookEntry = new Book();
                        bookEntry.title = book.GetChildText("title");
                        if (bookEntry.title == null)
                        {
                            throw new ArgumentException("Provided book does not have an title!");
                        }

                        var authors = book.SelectNodes("authors/author");
                        if (authors.Count == 0)
                        {
                            throw new ArgumentException("Cannot create book with missing author!");
                        }

                        foreach (XmlNode author in authors)
                        {
                            var name = author.InnerText;
                            bookEntry.Authors.Add(CreateOrLoadAuthor(dbCon, name));
                        }

                        foreach (XmlNode review in book.SelectNodes("reviews/review"))
                        {
                            string authorName = null;
                            var currentReview = new Review();
                            DateTime date = DateTime.Now;

                            if (review.Attributes["author"] != null)
                            {
                                authorName = review.Attributes["author"].Value;
                                var author = CreateOrLoadAuthor(dbCon, authorName);
                                currentReview.AuthorId = author.Id;
                            }
                            if (review.Attributes["date"] != null)
                            {
                                date = DateTime.Parse(review.Attributes["date"].Value);
                            }

                            var text = review.InnerText;
                            currentReview.DateOfCreation = date;
                            currentReview.Text = text;
                            dbCon.Reviews.Add(currentReview);

                            dbCon.SaveChanges();
                            bookEntry.Reviews.Add(currentReview);
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
                        dbCon.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Transaction failed to complete with the following error: \n" + ex.Message.ToString());

                        Environment.Exit(2);
                    }
                    tran.Complete();
                }
            }
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

