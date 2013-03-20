using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CreatingGenericList.Common
{
    public class MyList<T>
    {
        private int counter = 0;
        private T[] array;

        public MyList(int arrayLength)
        {
            array = new T[arrayLength];
        }

        public T Min()
        {
            return array.Min();
        }

        public T Max()
        {
            return array.Max();
        }

        public void AddElement(T element)
        {
            if (counter + 1 >= array.Length)
            {
                array = (T[])ExtendArray();
            }

            array[counter] = element;
            counter++;
        }

        public void AddElementAtIndex(int index, T element)
        {
            try
            {
                List<T> newList = new List<T>();

                foreach (var elements in array)
                {
                    newList.Add(elements);
                }
                newList.Insert(index, element);
                T[] newArr = new T[newList.Count];
                int possition = 0;
                foreach (var listElement in newList)
                {
                    newArr[possition] = listElement;
                    possition++;
                }
                array = (T[])newArr.Clone();
                counter++;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Index was outside the boundaries of the array!.This command will not be fullfiled");
            }
        }

        public void RemoveElementAtIndex(int index)
        {
            try
            {
                List<T> newList = new List<T>();
                foreach (var elements in array)
                {
                    newList.Add(elements);
                }
                newList.RemoveAt(index);
                T[] newArr = new T[newList.Count];
                int possition = 0;
                foreach (var listElement in newList)
                {
                    newArr[possition] = listElement;
                    possition++;
                }
                array = (T[])newArr.Clone();
                counter--;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Index was outside the boundaries of the array!.This command will not be fullfiled");
            }
        }

        public T[] ExtendArray()
        {
            T[] newArray = new T[array.Length * 2];
            int possition = 0;
            foreach (var element in array)
            {
                newArray[possition] = element;
                possition++;
            }
            return newArray;
        }

        public int Length()
        {
            return array.Length;
        }

        public void Clear()
        {
            array = new T[0];
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var element in array)
            {
                result.Append(element + "\n");
            }
            return result.ToString();
        }

        public T this[int index]
        {
            get
            {
                if (index >= array.Length || index < 0)
                {
                    Console.WriteLine("Index was outside the boundaries of the array!.This command will not be fullfiled");
                }
                T result = array[index];
                return result;
            }
        }

    }
}

