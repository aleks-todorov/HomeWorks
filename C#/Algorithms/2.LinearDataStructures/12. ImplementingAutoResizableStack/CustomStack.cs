using System;

public class CustomStack<T>
{
    private T[] stackArray;
    private int counter = 0;

    public CustomStack()
    {
        stackArray = new T[2];
    }

    public void Push(T item)
    {
        if (counter + 1 >= stackArray.Length)
        {
            ResizeArray();
        }

        stackArray[counter] = item;
        counter++;
    }

    public T Pop()
    {
        if (counter - 1 < 0)
        {
            throw new NullReferenceException("Cannot remove element from empty Stack");
        }

        counter--;
        return stackArray[counter];
    }

    public int Count()
    {
        return counter;
    }

    private void ResizeArray()
    {
        T[] newArray = new T[stackArray.Length * 2];

        for (int i = 0; i < stackArray.Length; i++)
        {
            newArray[i] = stackArray[i];
        }

        stackArray = new T[newArray.Length];

        //Not the best way to copy arrays, but for the demo purposes it works. 
        Array.Copy(newArray, stackArray, newArray.Length);
    }
}
