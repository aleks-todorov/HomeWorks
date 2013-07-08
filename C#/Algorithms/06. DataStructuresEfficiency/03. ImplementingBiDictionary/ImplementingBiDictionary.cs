using System;

class ImplementingBiDictionary
{
    /* Task 3: 
     * Implement a class BiDictionary<K1,K2,T> that allows adding triples {key1, key2, value} and 
     * fast search by key1, key2 or by both key1 and key2. Note: multiple values can be stored for given key.
     */

    //Note: since removing of keys is not requested I have not implemented it. 

    static void Main(string[] args)
    {
        var biDictionary = new BiDictionary<string, int, int>();

        biDictionary.Add("Pesho", 4);
        biDictionary.Add("Pesho", 5);
        biDictionary.Add("Pesho", 3);
        biDictionary.Add(23, 6);
        biDictionary.Add("Maria", 13, 5);
        biDictionary.Add("Maria", 13, 2);
        biDictionary.Add("Maria", 13, 4);
        biDictionary.Add("Maria", 13, 6);

        foreach (var item in biDictionary.GetValueByFirstKey("Pesho"))
        {
            Console.WriteLine(item);
        }

        foreach (var item in biDictionary.GetValueBySecondKey(23))
        {
            Console.WriteLine(item);
        }

        foreach (var item in biDictionary.GetValueByBothKeys("Maria", 13))
        {
            Console.WriteLine(item);
        }
    }
}

