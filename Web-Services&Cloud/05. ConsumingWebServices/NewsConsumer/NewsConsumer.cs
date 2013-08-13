using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;

namespace NewsConsumer
{
    class NewsConsumer
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("http://api.feedzilla.com/v1/");

            var categoryId = GetCategories(httpClient);

            //Value must be between 0 and 100  
            Console.WriteLine("Please enter number of articles[0-100]");
            var numberOfArticles = int.Parse(Console.ReadLine());

            var httpClientForNews = new HttpClient();
            var url = string.Format("http://api.feedzilla.com/v1/categories/{0}/", categoryId);

            httpClientForNews.BaseAddress = new Uri(url);

            GetNews(httpClientForNews, numberOfArticles);

            //Needed to slow the program untill the requests are done async. 
            Thread.Sleep(500);
        }

        private static int GetCategories(HttpClient httpClient)
        {
            var response = httpClient.GetAsync("categories.json").Result;
            var categoriesAsString = response.Content.ReadAsStringAsync().Result;
            var categories = JsonConvert.DeserializeObject<IList<Category>>(categoriesAsString);
            PrintCategories(categories);
            var choice = int.Parse(Console.ReadLine()) - 1;
            var categoryId = categories[choice].Category_id;
            return categoryId;
        }

        private static void PrintCategories(IList<Category> categories)
        {
            Console.WriteLine("Categoreis: ");
            var sb = new StringBuilder();
            for (int i = 0; i < categories.Count; i++)
            {
                sb.AppendLine(i + 1 + ". " + categories[i].English_category_name);
            }

            Console.WriteLine(sb.ToString());
            Console.WriteLine("Please select desired category: ");
        }

        static async void GetNews(HttpClient httpClient, int numberOfArticles)
        {
            var response = await httpClient.GetAsync(string.Format("articles.json?count={0}", numberOfArticles));
            var articlesAsString = await response.Content.ReadAsStringAsync();
            var articles = JsonConvert.DeserializeObject<NewsList>(articlesAsString);
            PrintNews(articles);
        }

        private static void PrintNews(NewsList articles)
        {
            var sb = new StringBuilder();

            if (articles.Articles.Count == 0)
            {
                Console.WriteLine("There are no news for this category!");
            }

            foreach (var a in articles.Articles)
            {
                sb.AppendLine("News:");
                sb.AppendLine("Title: " + a.Title);
                sb.AppendLine("URL: " + a.Url);
                sb.AppendLine(new string('-', Console.WindowWidth));
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
