using System;
using System.Linq;

namespace WordOccurenceClient
{
    class CounterClient
    {
        static void Main(string[] args)
        {
            var counter = new WcfServiceOccurenceCounter.ServiceWordCounter();

            var subString = "ha";
            var word = "hahahahaha";

            var result = counter.GetData(subString, word);
            Console.WriteLine(result);
        }
    }
}
