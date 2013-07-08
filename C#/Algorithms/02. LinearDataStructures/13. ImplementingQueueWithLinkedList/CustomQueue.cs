using System;
using System.Collections.Generic;
using System.Linq;

class CustomQueue<T>
{
    private LinkedList<T> queue;
    private int counter = 0;

    public CustomQueue()
    {
        this.queue = new LinkedList<T>();
    }

    public void Enqueue(T item)
    {
        if (counter == 0)
        {
            queue.AddFirst(item);
        }
        else
        {
            queue.AddLast(item);
        }
        counter++;
    }

    public T Dequeue()
    {
        if (queue.First == null)
        {
            throw new NullReferenceException("Cannot remove element from empty Queue");
        }

        var firstElement = queue.First();
        queue.RemoveFirst();
        counter--;
        return firstElement;
    }

    public int Count()
    {
        return counter;
    }
}
