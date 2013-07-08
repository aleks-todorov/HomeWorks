using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

class ArticalManagement
{
    /* Task 2: 
     * A large trade company has millions of articles, each described by barcode, 
     * vendor, title and price. Implement a data structure to store them that allows fast retrieval of 
     * all articles in given price range [x…y]. Hint: use OrderedMultiDictionary<K,T> from 
     * Wintellect's Power Collections for .NET. 
     */

    static void Main(string[] args)
    {
        var randomGenerator = new Random();
        var articlesHolder = new OrderedMultiDictionary<double, Article>(true);

        //This takes few seconds...
        for (int i = 0; i < 300000; i++)
        {
            var barcode = Convert.ToString(i, 2);
            var vendor = "Vendor" + i;
            var title = "Title" + i;
            var price = randomGenerator.NextDouble() * randomGenerator.Next(0, 10000000);
            var article = new Article(barcode, vendor, title, price);
            articlesHolder.Add(article.Price, article);
        }

        var articlesInRange = articlesHolder.Range(100.0, true, 500.0, true);

        foreach (var article in articlesInRange)
        {
            Console.WriteLine(article.Value.ToString());
            Console.WriteLine();
        }
    }
}