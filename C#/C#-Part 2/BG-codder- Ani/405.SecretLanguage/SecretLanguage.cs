using System;
using System.Linq;

//40/100 :(
class SecretLanguage
{
    static void Main(string[] args)
    {
        string sentence = Console.ReadLine();
        string wordsInput = Console.ReadLine();

        string[] words = wordsInput.Split(new char[] { ' ', ',', '\"' }, StringSplitOptions.RemoveEmptyEntries);
        words.OrderBy(x => x.Length);
        string[] wordsSorted = new string[words.Length];
        for (int i = 0; i < words.Length; i++)
        {
            char[] intermediate = words[i].ToCharArray();
            Array.Sort(intermediate);
            wordsSorted[i] = new string(intermediate);
        }

        int[] minPrice = new int[sentence.Length + 1];
        minPrice[0] = 0;
        for (int i = 1; i < minPrice.Length; i++)
        {
            minPrice[i] = 1000000;
        }

        for (int i = 1; i < minPrice.Length; i++)
        {
            int prevWordLength = wordsSorted[0].Length;
            if (prevWordLength <= i)
            {
                char[] partOfSentence = new char[prevWordLength];
                char[] partOfSentenceSorted = new char[prevWordLength];
                sentence.CopyTo(i - prevWordLength, partOfSentence, 0, prevWordLength);
                sentence.CopyTo(i - prevWordLength, partOfSentenceSorted, 0, prevWordLength);
                Array.Sort(partOfSentenceSorted);
                for (int u = 0; u < wordsSorted.Length; u++)
                {
                    int currentWordLength = wordsSorted[u].Length;
                    if (currentWordLength != prevWordLength)
                    {
                        if (currentWordLength <= i)
                        {
                            currentWordLength = wordsSorted[u].Length;
                            partOfSentence = new char[currentWordLength];
                            partOfSentenceSorted = new char[currentWordLength];
                            sentence.CopyTo(i - currentWordLength, partOfSentence, 0, currentWordLength);
                            sentence.CopyTo(i - currentWordLength, partOfSentenceSorted, 0, currentWordLength);
                            Array.Sort(partOfSentenceSorted);
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (new string(partOfSentenceSorted) == wordsSorted[u])
                    {
                        int currentPrice = CalculatePrice(partOfSentence, words[u]);
                        if (currentPrice + minPrice[i - currentWordLength] < minPrice[i])
                        {
                            minPrice[i] = currentPrice + minPrice[i - currentWordLength];
                        }
                    }
                }
            }
        }

        if (minPrice[minPrice.Length - 1] == 1000000)
        {
            Console.WriteLine(-1);
        }
        else
        {
            Console.WriteLine(minPrice[minPrice.Length - 1]);
        }
    }

    static int CalculatePrice(char[] partOfSentence, string word)
    {
        int price = 0;
        for (int i = 0; i < partOfSentence.Length; i++)
        {
            if (partOfSentence[i] != word[i])
            {
                price++;
            }
        }
        return price;
    }
}