using System;

class ImplementingHashTable
{

    /* Task 4: 
     * Implement the data structure "hash table" in a class HashTable<K,T>. 
     * Keep the data in array of lists of key-value pairs (LinkedList<KeyValuePair<K,T>>[]) 
     * with initial capacity of 16. When the hash table load runs over 75%, perform resizing to 2
     * times larger capacity. Implement the following methods and properties: Add(key, value), Find(key)value,
     * Remove( key), Count, Clear(), this[], Keys. Try to make the hash table to support iterating over its elements 
     * with foreach.
     */

    //Few functionalities are missing. If I have time I will add them as well. 

    static void Main(string[] args)
    {
        var hashTable = new HashTable<string, int>();

        for (int i = 0; i < 100; i++)
        {
            hashTable.Add("Entri" + i, i);
        }

        Console.WriteLine(hashTable.Count());
        Console.WriteLine(hashTable.Find("Entri50"));

        for (int i = 50; i < 100; i++)
        {
            hashTable.Remove("Entri" + i);
        }

        //Will throw an exception
        //Console.WriteLine(hashTable.Find("Entri50"));

        var keys = hashTable.Keys();

        foreach (var key in keys)
        {
            Console.WriteLine(key);
        }

        hashTable.Clear();
        Console.WriteLine(hashTable.Count());
    }
}

