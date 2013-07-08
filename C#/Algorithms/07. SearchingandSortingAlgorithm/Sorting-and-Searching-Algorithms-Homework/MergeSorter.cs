namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            Sorter(collection, 0, collection.Count);
        }

        private static void Sorter(IList<T> collection, int low, int high)
        {
            int N = high - low;
            if (N <= 1)
            {
                return;
            }

            int mid = low + N / 2;

            Sorter(collection, low, mid);
            Sorter(collection, mid, high);

            T[] aux = new T[N];

            int i = low;
            int j = mid;
            for (int k = 0; k < N; k++)
            {
                if (i == mid)
                {
                    aux[k] = collection[j++];
                }
                else if (j == high)
                {
                    aux[k] = collection[i++];
                }
                else if (collection[j].CompareTo(collection[i]) < 0)
                {
                    aux[k] = collection[j++];
                }
                else
                {
                    aux[k] = collection[i++];
                }
            }

            for (int k = 0; k < N; k++)
            {
                collection[low + k] = aux[k];
            }
        }
    }
}
