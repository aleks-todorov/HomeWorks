using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

class BiDictionary<K1, K2, T>
{
    private MultiDictionary<K1, T> dictionaryWithKeyOne;
    private MultiDictionary<K2, T> dictionaryWithKeyTwo;
    private MultiDictionary<Tuple<K1, K2>, T> dictionaryWithTuple;

    public BiDictionary()
    {
        this.dictionaryWithKeyOne = new MultiDictionary<K1, T>(true);
        this.dictionaryWithKeyTwo = new MultiDictionary<K2, T>(true);
        this.dictionaryWithTuple = new MultiDictionary<Tuple<K1, K2>, T>(true);
    }

    public void Add(K1 keyOne, T value)
    {
        this.dictionaryWithKeyOne.Add(keyOne, value);
    }

    public void Add(K2 keyTwo, T value)
    {
        this.dictionaryWithKeyTwo.Add(keyTwo, value);
    }

    public void Add(K1 keyOne, K2 keyTwo, T value)
    {
        var tuple = new Tuple<K1, K2>(keyOne, keyTwo);
        this.dictionaryWithTuple.Add(tuple, value);
    }

    public ICollection<T> GetValueByFirstKey(K1 key)
    {
        return this.dictionaryWithKeyOne[key];
    }

    public ICollection<T> GetValueBySecondKey(K2 key)
    {
        return this.dictionaryWithKeyTwo[key];
    }

    public ICollection<T> GetValueByBothKeys(K1 keyOne, K2 keyTwo)
    {
        var tuple = new Tuple<K1, K2>(keyOne, keyTwo);
        return this.dictionaryWithTuple[tuple];
    }
}

