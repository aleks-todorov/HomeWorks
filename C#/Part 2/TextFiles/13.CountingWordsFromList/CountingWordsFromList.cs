using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _10.ExtractTextFromXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = string.Empty;
            List<Words> wordList = new List<Words>();

            try
            {
                content = ReadingFromFileList(content);
                wordList = ReadingWordList(wordList).ToList();
                foreach (var word in wordList)
                {
                    int index = content.IndexOf(word.WordValue);
                    while (index != -1)
                    {
                        word.Occurence++;
                        index = content.IndexOf(word.WordValue, index + 1);
                    }
                }
                WriteMethod(wordList);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }
            catch (AccessViolationException)
            {
                Console.WriteLine("");
            }
            catch (System.NullReferenceException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (SystemException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        private static List<Words> ReadingWordList(List<Words> wordList)
        {
            StreamReader listReader = new StreamReader("../../words.txt");
            string line = listReader.ReadLine();
            while (line != null)
            {

                Words word = new Words(string.Empty, 0);
                word.WordValue = line;
                line = listReader.ReadLine();
                wordList.Add(word);
            }
            return wordList;
        }

        private static string ReadingFromFileList(string content)
        {

            StreamReader reader = new StreamReader("../../test.txt");
            using (reader)
            {
                content = reader.ReadToEnd();
            }
            return content;
        }

        private static void WriteMethod(List<Words> wordList)
        {
            wordList = wordList.OrderByDescending(t => t.Occurence).ToList();
            StreamWriter writer = new StreamWriter("../../result.txt");
            using (writer)
            {
                foreach (var word in wordList)
                    writer.WriteLine(word.WordValue + " " + word.Occurence);
            }
        }
    }

    class Words
    {
        private string wordValue;
        private int occurence = 0;

        public string WordValue
        {
            get { return this.wordValue; }
            set { this.wordValue = value; }
        }
        public int Occurence
        {
            get { return this.occurence; }
            set { this.occurence = value; }
        }

        public Words(string wordValue, int occurence)
        {
            this.wordValue = wordValue;
            this.occurence = occurence;
        }
    }
}
