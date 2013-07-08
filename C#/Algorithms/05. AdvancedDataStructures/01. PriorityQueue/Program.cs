using System;

class Program
{
    /* Task 1:  
     * Implement a class PriorityQueue<T> based on the data structure "binary heap".
     */

    static void Main(string[] args)
    {
        var prioQueue = new PriorityQueue<int>();

        prioQueue.Add(25);
        prioQueue.Add(15);
        prioQueue.Add(105);
        prioQueue.Add(5);
        prioQueue.Add(35);

        Console.WriteLine(prioQueue.Count());
        Console.WriteLine(prioQueue.Dequeue());
        Console.WriteLine(prioQueue.Dequeue());
        Console.WriteLine(prioQueue.Dequeue());
        Console.WriteLine(prioQueue.Dequeue());
    }
}

