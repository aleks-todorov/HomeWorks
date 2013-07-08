using System;
using System.Collections.Generic;
using System.Linq;


class PriorityQueue<T> : ICollection<T> where T : IComparable<T>
{
    private BinaryHeap<T> queue;

    public PriorityQueue()
    {
        queue = new BinaryHeap<T>();
    }

    public int Count()
    {
        return this.queue.Count();
    }

    public void Enqueue(T element)
    {
        this.queue.Add(element);
    }

    public T Dequeue()
    {
        return this.queue.Remove();
    }

    public void Add(T item)
    {
        this.Enqueue(item);
    }

    public void Clear()
    {
        this.queue.Clear();
    }

    public bool Contains(T item)
    {
        return this.queue.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    int ICollection<T>.Count
    {
        get { throw new NotImplementedException(); }
    }

    public bool IsReadOnly
    {
        get { throw new NotImplementedException(); }
    }

    public bool Remove(T item)
    {
        this.Dequeue();
        return true;
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

