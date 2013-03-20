using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CreatingGenericList.Common
{
    public class GenericList<T>
    {
        private int counter = 0;
        private T[] array;


        public GenericList(int arrayLength)
        {
            array = new T[arrayLength];
        }

        public void AddElement(T element)
        {
            if (counter > array.Length)
            {
                array = ExtendArray();
            }

            array[counter] = element;

            counter++;
        }

        private T[] ExtendArray()
        {
            T[] newArray = new T[array.Length * 2];
            newArray = array.Clone();
            return newArray;
        }
    }
}

