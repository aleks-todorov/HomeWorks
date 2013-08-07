using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Bookmarks.Data;
using System.Transactions;

namespace BookmarksImporter
{
    static class Program
    {
        static void Main(string[] args)
        {
            var tran = new TransactionScope();
            using (tran)
            {
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load("../../bookmarks.xml");
                    string xPathQuery = "/bookmarks/bookmark";

                    XmlNodeList bookmarksList = xmlDoc.SelectNodes(xPathQuery);
                    foreach (XmlNode bookmarkNode in bookmarksList)
                    {
                        string userName = bookmarkNode.GetChildText("username");
                        string title = bookmarkNode.GetChildText("title");
                        string url = bookmarkNode.GetChildText("url");
                        string notes = bookmarkNode.GetChildText("notes");
                        string allTags = bookmarkNode.GetChildText("tags");
                        string[] tags = { };

                        if (allTags != null)
                        {
                            tags = allTags.Split(' ');
                            for (int i = 0; i < tags.Length; i++)
                            {
                                tags[i] = tags[i].Trim();
                            }
                        }
                        AddBookmark(userName, title, url, tags, notes);
                    }
                    tran.Complete();
                }
                catch (Exception)
                {
                    Console.WriteLine("Transaction failed!");
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
            else
            {
                return childNode.InnerText;
            }
        }

        private static void AddBookmark(string username, string title, string url, string[] tags, string notes)
        {
            BookmarksDAL.AddBookmarks(username, title, url, tags, notes);
        }
    }
}

