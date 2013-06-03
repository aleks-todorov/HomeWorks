using System;

class Application
{
    /* Task 13: 
     * Implement the ADT queue as dynamic linked list.
     * Use generics (LinkedQueue<T>) to allow storing different data types in the queue.
     */

    static void Main(string[] args)
    {
        var customQueue = new CustomQueue<int>();
        customQueue.Enqueue(15);
        customQueue.Enqueue(25);
        customQueue.Enqueue(35);
        customQueue.Enqueue(45);

        Console.WriteLine("Custom Queue Count: {0}", customQueue.Count());
        Console.WriteLine("Removed element {0}", customQueue.Dequeue());
        Console.WriteLine("Custom Queue Count: {0}", customQueue.Count());
    }
}

