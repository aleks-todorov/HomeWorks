using System;
using System.Collections.Generic;
using System.Linq;

class HashedSet<T> : IEnumerable<T>
{
    //I am using Dictionary since there are missing functionalities in my HashSet class. 
    private Dictionary<T, T> content;

    public HashedSet()
    {
        this.content = new Dictionary<T, T>();
    }

    public void Add(T value)
    {
        content.Add(value, value);
    }

    public T Find(T value)
    {
        if (this.content.ContainsKey(value))
        {
            return this.content[value];
        }

        throw new ArgumentException("This key cannot be found! ");
    }

    public void Remove(T value)
    {
        this.content.Remove(value);
    }

    public int Count()
    {
        return this.content.Count();
    }

    public void Clear()
    {
        this.content.Clear();
    }

    public HashedSet<T> Union(HashedSet<T> set)
    {
        //Pretty slow implementation. Have to look for better one. 
        var unitedSet = new HashedSet<T>();
        foreach (var item in this.content)
        {
            unitedSet.Add(item.Value);
        }

        foreach (var item in set)
        {
            if (!unitedSet.HasEntry(item))
            {
                unitedSet.Add(item);
            }
        }

        return unitedSet;
    }

    public bool HasEntry(T value)
    {
        if (this.content.ContainsKey(value))
        {
            return true;
        }
        return false;
    }

    public HashedSet<T> Intersect(HashedSet<T> set)
    {
        var intersectedSet = new HashedSet<T>();

        foreach (var item in this.content)
        {
            if (set.HasEntry(item.Value))
            {
                intersectedSet.Add(item.Value);
            }
        }

        return intersectedSet;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (T t in this.content.Values)
        {
            // Lets check for end of list (its bad code since we used arrays)
            if (t == null) // this wont work is T is not a nullable type
            {
                break;
            }

            // Return the current element and then on next function call 
            // resume from next element rather than starting all over again;
            yield return t;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

