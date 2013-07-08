using System;
using System.Collections.Generic;

class Application
{
    /* Task 5: 
     * Write a program that removes from given sequence all negative numbers. 
     */

    static void Main(string[] args)
    {
        var numberSequence = new List<int> { 0, 1, -4, 1, -5, 1, -2, 1, 6, 5, 3, -9 };
        numberSequence.RemoveAll(x => x < 0);

        foreach (var number in numberSequence)
        {
            Console.Write("{0} ", number);
        }
    }
}
