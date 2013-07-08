using System;

class ImplementingSet
{
    /* Task 5: 
     * Implement the data structure "set" in a class HashedSet<T> using your class HashTable<K,T>
     * to hold the elements. Implement all standard set operations like Add(T), Find(T), Remove(T),
     * Count, Clear(), union and intersect.
     */

    static void Main(string[] args)
    {
        var setOne = new HashedSet<int>();

        for (int i = 0; i < 50; i++)
        {
            setOne.Add(i);
        }

        Console.WriteLine(setOne.Count());

        for (int i = 25; i < 50; i++)
        {
            setOne.Remove(i);
        }

        Console.WriteLine(setOne.Count());

        var setTwo = new HashedSet<int>();

        setTwo.Add(100);
        setTwo.Add(101);
        setTwo.Add(102);
        setTwo.Add(103);
        setTwo.Add(104);
        setTwo.Add(105);

        //Saving all results from Union
        setOne = setOne.Union(setTwo);
        Console.WriteLine(setOne.Count());

        setTwo.Clear();
        for (int i = 10; i < 25; i++)
        {
            setTwo.Add(i);
        }

        //Saving only the intersect Results
        setOne = setOne.Intersect(setTwo);
        Console.WriteLine(setOne.Count());
    }
}