using System;
using System.Collections.Generic;
using System.Linq;

public class HashTable<K, T>
{
    private LinkedList<KeyValuePair<K, T>>[] content;
    private int index = 0;
    private HashSet<K> keys;

    public HashTable()
    {
        this.content = new LinkedList<KeyValuePair<K, T>>[16];
        this.keys = new HashSet<K>();
    }

    public void Add(K key, T value)
    {
        if (index > content.Length * 0.75)
        {
            ResizeArray();
        }

        content[index] = new LinkedList<KeyValuePair<K, T>>();
        var keyValuePair = new KeyValuePair<K, T>(key, value);
        content[index].AddLast(keyValuePair);
        keys.Add(key);
        index++;
    }

    private void ResizeArray()
    {
        var resizedArray = new LinkedList<KeyValuePair<K, T>>[content.Length * 2];
        Array.Copy(this.content, resizedArray, content.Length);
        this.content = resizedArray;
    }

    public T Find(K key)
    {
        try
        {
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i] == null)
                {
                    throw new ArgumentException();
                }

                foreach (var item in content[i])
                {
                    //The first way for comparing Generic Types that came on my mind. Not the best practice though. 
                    if ((dynamic)item.Key == (dynamic)key)
                    {
                        return item.Value;
                    }
                }
            }

            throw new ArgumentException();
        }
        catch (ArgumentException)
        {
            throw new ArgumentException("Given key cannot be found!");
        }
    }

    public void Remove(K key)
    {
        for (int i = 0; i < content.Length; i++)
        {
            if (content[i] == null)
            {
                continue;
            }

            foreach (var item in content[i])
            {
                //The first way for comparing Generic Types that came on my mind. Not the best practice though. 
                if ((dynamic)item.Key == (dynamic)key)
                {
                    keys.Remove(key);
                    content[i] = null;
                }
            }
        }
    }

    public int Count()
    {
        return keys.Count();
    }

    public HashSet<K> Keys()
    {
        return this.keys;
    }

    public void Clear()
    {
        this.content = new LinkedList<KeyValuePair<K, T>>[16];
        this.index = 0;
        this.keys.Clear();
    }
}

