using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCounter
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Counter : ICounter
    {
        public int GetData(string subString, string word)
        {
            var result = CountOccurence(subString, word);

            return result;
        }

        private int CountOccurence(string subString, string word)
        {
            int count = new Regex(subString).Matches(word).Count;

            return count;
        }
    }
}
