using System;
using System.Collections.Generic;
using System.Linq;

class CountingOccurenceOfWords
{
    /* Task 3: 
     * Write a program that counts how many times each word from given
     * text file words.txt appears in it. The character casing differences should be 
     * ignored. The result words should be ordered by their number of occurrences in the text. Example:
     
         This is the TEXT. Text, text, text – THIS TEXT! Is this the text?
     
	  * is  2
	  * the  2
	  * this  3
	  * text  6
    */

    static void Main(string[] args)
    {
        string text = "This is the TEXT. Text, text, text - THIS TEXT! Is this the text?";
        var occurenceHolder = new SortedDictionary<string, int>();
        char[] separators = { ' ', ',', '-', '?', '.', '!' };
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].ToLower();
            if (occurenceHolder.ContainsKey(words[i]))
            {
                occurenceHolder[words[i]]++;
            }
            else
            {
                occurenceHolder[words[i]] = 1;
            }
        }
         
        var items = from pair in occurenceHolder
                    orderby pair.Value ascending
                    select pair;

        foreach (var item in items)
        {
            Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
        }
    }
}
