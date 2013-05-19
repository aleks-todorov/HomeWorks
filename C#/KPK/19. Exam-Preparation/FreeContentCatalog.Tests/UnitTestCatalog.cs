using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatalogOfFreeContent;
using System.Linq;

namespace FreeContentCatalog.Tests
{
    [TestClass]
    public class UnitTestCatalog
    {
        [TestMethod]
        public void TestMethodAddSingleItem()
        {
            var catalog = new Catalog();
            string[] item = {
                               "Intro C#", 
                               "S.Nakov", 
                               "12763892", 
                               "http://www.introprogramming.info"
                               };
            var book = new ContentItem(ContentItemType.Book, item);
            catalog.Add(book);
            Assert.AreEqual(catalog.Count(), 1);
        }

        [TestMethod]
        public void TestMethodAddAndCheckContent()
        {
            var catalog = new Catalog();
            string[] book = {
                               "Intro C#", 
                               "S.Nakov", 
                               "12763892", 
                               "http://www.introprogramming.info"
                               };
            var item = new ContentItem(ContentItemType.Book, book);
            catalog.Add(item);
            var restult = catalog.GetListContent("Intro C#", 1);
            Assert.AreEqual(restult.Count(), 1);
            Assert.AreSame(restult.First(), item);
        }

        [TestMethod]
        public void TestMethodAddDuplicatedItems()
        {
            var catalog = new Catalog();
            string[] book = {
                               "Intro C#", 
                               "S.Nakov", 
                               "12763892", 
                               "http://www.introprogramming.info"
                               };
            var item1 = new ContentItem(ContentItemType.Book, book);
            var item2 = new ContentItem(ContentItemType.Book, book);
            catalog.Add(item1);
            catalog.Add(item2);
            var restult = catalog.GetListContent("Intro C#", 5);
            Assert.AreEqual(restult.Count(), 2);

        }

        [TestMethod]
        public void TestMethodAddDuplicatedItemsWithSameValues()
        {
            var catalog = new Catalog();
            string[] book = {
                               "Intro C#", 
                               "S.Nakov", 
                               "12763892", 
                               "http://www.introprogramming.info"
                               };

            var item1 = new ContentItem(ContentItemType.Book, book);
            catalog.Add(item1);
            catalog.Add(item1);
            var restult = catalog.GetListContent("Intro C#", 5);
            Assert.AreEqual(restult.Count(), 2);

        }

        [TestMethod]
        public void TestMethodAddMultipleItems()
        {
            var catalog = new Catalog();
            var book = new ContentItem(ContentItemType.Book, new string[] {
                               "Intro C#","S.Nakov","12763892","http://www.introprogramming.info"});


            var movie = new ContentItem(ContentItemType.Movie, new string[] {
                               "The Secret","Sean Byrne & others (2006)","832763834","http://thesecret/movies/avi"});


            var song = new ContentItem(ContentItemType.Song, new string[] {
                               "The Secret Song","Sean Byrne & others (2006)","832763834","http://thesecret/songs/mp3"});

            catalog.Add(book);
            catalog.Add(movie);
            catalog.Add(song);
            Assert.AreEqual(catalog.Count(), 3);
        }

        [TestMethod]
        [Timeout(1000)]
        public void TestMethodAdd50kItems()
        {
            var catalog = new Catalog();
            for (int i = 0; i < 10000; i++)
            {
                var book = new ContentItem(ContentItemType.Book, new string[] {
                               "Intro C#" + i,"S.Nakov","12763892","http://www.introprogramming.info"});
                catalog.Add(book);
            }

            Assert.AreEqual(catalog.Count(), 10000);
        }

        [TestMethod]
        public void TestMethodGetListContentManyMatchingItemsGetFirstOnly()
        {
            var catalog = new Catalog();

            var book1 = new ContentItem(ContentItemType.Book, new string[] {
                               "Intro C#" ,"S.Nakov","12763892","http://www.introprogramming.info"});
            var book2 = new ContentItem(ContentItemType.Book, new string[] {
                               "Intro C++" ,"S.Nakov","12763892","http://www.introprogramming.info"});
            var book3 = new ContentItem(ContentItemType.Book, new string[] {
                               "Intro Java" ,"S.Nakov","12763892","http://www.introprogramming.info"});
            var book4 = new ContentItem(ContentItemType.Book, new string[] {
                               "Intro C#" ,"Author","127623892","http://www.introprogramming.info"});

            catalog.Add(book1);
            catalog.Add(book2);
            catalog.Add(book3);
            catalog.Add(book4);

            var result = catalog.GetListContent("Intro C#", 1);
            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        public void TestMethodGetListContentCheckOrder()
        {
            var catalog = new Catalog();

            var book1 = new ContentItem(ContentItemType.Book, new string[] {
                               "Intro C#" ,"S.Nakov","12763892","http://www.introprogramming.info"});
            var book2 = new ContentItem(ContentItemType.Book, new string[] {
                               "Intro C#" ,"Author","12763892","http://www.introprogramming.info"});
            var book3 = new ContentItem(ContentItemType.Book, new string[] {
                               "Intro C#" ,"Xray","12763892","http://www.introprogramming.info"});
            var book4 = new ContentItem(ContentItemType.Book, new string[] {
                               "Intro C#" ,"Author","127623892","http://www.introprogramming.info"});

            catalog.Add(book1);
            catalog.Add(book2);
            catalog.Add(book3);
            catalog.Add(book4);

            var result = catalog.GetListContent("Intro C#", 10);
            Assert.AreEqual(result.Count(), 4);

            var expected = new string[] {"Book: Intro C#; Author; 127623892; http://www.introprogramming.info",
"Book: Intro C#; Author; 12763892; http://www.introprogramming.info",
"Book: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info",
"Book: Intro C#; Xray; 12763892; http://www.introprogramming.info"};

            var actual = new string[]{
                result.First().ToString(),
                result.Skip(1).First().ToString(), 
                 result.Skip(2).First().ToString(), 
                result.Skip(3).First().ToString()
            };

            CollectionAssert.AreEqual(expected, actual);
        }

    }
}
