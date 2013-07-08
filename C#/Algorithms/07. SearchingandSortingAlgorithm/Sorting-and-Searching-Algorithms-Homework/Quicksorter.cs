namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    //Implementing the QuickSort algorithm explained in Sedgewek course for Algorithms
    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            Sorter(collection, 0, collection.Count - 1);
        }

        private void Sorter(IList<T> collection, int low, int high)
        {
            if (high <= low) return;
            int j = Particioning(collection, low, high);
            Sorter(collection, low, j - 1);
            Sorter(collection, j + 1, high);
        }

        private static int Particioning(IList<T> collection, int low, int high)
        {
            int i = low;
            int j = high + 1;


            while (true)
            {
                while ((dynamic)collection[++i] < (dynamic)collection[low])
                {
                    if (i == high)
                    {
                        break;
                    }
                }

                while ((dynamic)collection[low] < (dynamic)collection[--j])
                {
                    if (j == low)
                    {
                        break;
                    }
                }

                if (i >= j)
                {
                    break;
                }

                SwapValues(collection, low, j);

            }

            SwapValues(collection, low, j);

            return j;
        }

        private static void SwapValues(IList<T> collection, int low, int j)
        {
            var temp = collection[low];
            collection[low] = collection[j];
            collection[j] = temp;
        }
    }
}
