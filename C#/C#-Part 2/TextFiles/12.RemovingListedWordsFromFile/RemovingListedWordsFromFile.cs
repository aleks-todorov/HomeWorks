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
            List<string> wordList = new List<string>();
            try
            {
                content = ReadingFromFileList(content);
                wordList = ReadingWordList(wordList).ToList();
                foreach (var word in wordList)
                {
                    content = content.Replace(word, "...");
                }
                WriteMethod(content);
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

        private static List<string> ReadingWordList(List<string> wordList)
        {
            StreamReader listReader = new StreamReader("../../word-list.txt");
            string line = listReader.ReadLine();
            while (line != null)
            {
                wordList.Add(line);
                line = listReader.ReadLine();
            }
            return wordList;

        }


        private static string ReadingFromFileList(string content)
        {

            StreamReader reader = new StreamReader("../../input.txt");
            using (reader)
            {
                content = reader.ReadToEnd();
            }
            return content;
        }

        private static void WriteMethod(string content)
        {

            StreamWriter writer = new StreamWriter("../../output.txt");
            using (writer)
            {
                writer.WriteLine(content);
            }
        }
    }
}
