using System.Collections.Generic;

namespace NewsConsumer
{
    public class NewsList
    {
        public List<News> Articles { get; set; }
        public string Description { get; set; }
        public string SyndicationUrl { get; set; }
        public string Title { get; set; }
    }
}
