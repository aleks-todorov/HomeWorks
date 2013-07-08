using System.Collections.Generic;

public class NewLinkedList<T> : IEnumerable<T>
{
    public ListItem<T> FirstElement { get; set; }
    public ListItem<T> CurrentElement { get; set; }
    private int counter;

    public NewLinkedList()
    {
        this.CurrentElement = null;
        this.FirstElement = null;
    }

    public void Add(T item)
    {
        ListItem<T> newElement = new ListItem<T>();
        newElement.Value = item;
        newElement.NextItem = CurrentElement;
        CurrentElement = newElement;

        counter++;
    }

    public int Count()
    {
        return counter;
    }

    public IEnumerator<T> GetEnumerator()
    {
        this.FirstElement = this.CurrentElement;

        while (CurrentElement != null)
        {
            yield return CurrentElement.Value;
            CurrentElement = CurrentElement.NextItem;
        }

        this.CurrentElement = this.FirstElement;
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

