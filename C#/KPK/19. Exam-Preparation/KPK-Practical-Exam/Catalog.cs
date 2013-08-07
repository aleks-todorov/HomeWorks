using CatalogOfFreeContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace FreeContentCatalog
{
    public class Catalog : ICatalog
    {
        private MultiDictionary<string, IContent> url;
        private OrderedMultiDictionary<string, IContent> title;

        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.title = new OrderedMultiDictionary<string,
                IContent>(allowDuplicateValues);
            this.url = new MultiDictionary<string,
                IContent>(allowDuplicateValues);
        }

        public void Add(IContent content)
        {
            this.title.Add(content.Title, content);
            this.url.Add(content.URL, content);
        }

        public IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList)
        {
            IEnumerable<IContent> contentToList =
                from currentTitle in this.title[title]
                select currentTitle;

            return contentToList.Take(numberOfContentElementsToList);
        }

        public int UpdateContent(string oldUrl, string newUrl)
        {
            int numberOfUpdatedElements = 0;

            List<IContent> contentToList = this.url[oldUrl].ToList();

            foreach (ContentItem content in contentToList)
            {
                this.title.Remove(content.Title, content);
                content.URL = newUrl;
                this.title.Add(content.Title, content);
                this.url.Add(content.URL, content);
                numberOfUpdatedElements++;
            }

            return numberOfUpdatedElements;
        }

        public int Count()
        {
            var counter = 0;
            foreach (var item in this.title)
            {
                counter++;
            }
            return counter;
        }
    }
}
