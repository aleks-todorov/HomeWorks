using System;

class Application
{
    /* Task 11: 
     * Implement the data structure linked list. 
     * Define a class ListItem<T> that has two fields: value (of type T) 
     * and NextItem (of type ListItem<T>). Define additionally a class LinkedList<T>
     * with a single field FirstElement (of type ListItem<T>).
     */

    static void Main(string[] args)
    {
        var linkedList = new NewLinkedList<int>();

        linkedList.Add(10);
        linkedList.Add(15);
        linkedList.Add(20);

        foreach (var item in linkedList)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Total Elements Count: {0}", linkedList.Count());
    }
}
