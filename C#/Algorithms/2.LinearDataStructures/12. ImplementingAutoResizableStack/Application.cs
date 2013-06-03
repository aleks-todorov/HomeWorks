using System;

class Applciation
{
    /* Task 12: 
     * Implement the ADT stack as auto-resizable array. 
     * Resize the capacity on demand (when no space is available to add / insert a new element).
     */

    static void Main(string[] args)
    {
        var stackArray = new CustomStack<int>();

        for (int i = 1; i <= 100; i++)
        {
            stackArray.Push(i);
        }

        Console.WriteLine("Total Elements Count : {0}", stackArray.Count());
        stackArray.Push(999);
        Console.WriteLine("Total Elements Count : {0}", stackArray.Count());
        Console.WriteLine(stackArray.Pop());
        Console.WriteLine(stackArray.Pop());
        Console.WriteLine(stackArray.Pop());
        Console.WriteLine(stackArray.Pop());
        Console.WriteLine("Total Elements Count : {0}", stackArray.Count());
    }
}