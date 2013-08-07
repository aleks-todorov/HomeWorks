using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmarkSearch
{
    class BookmarkSearch
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../simple-query.xml");
            string useName = xmlDoc.GetChildText(useName);

            XmlNodeList bookmarksList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode bookmarkNode in bookmarksList)
            {
                string userName = bookmarkNode.GetChildText("query/username");
            }
        }
        private static string GetChildText(this XmlNode node, string xPatch)
        {
            XmlNodeList bookmarksList = xmlDoc.SelectNodes(xPatch);

            if (childNode == null)
            {
                return null;
            }
            else
            {
                return childNode.InnerText;
            }
        }
    }
}
