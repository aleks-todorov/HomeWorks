namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    //Implementing the Selection Sort algorithm explained in Sedgewek course for Algorithms
    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                var min = collection[i];
                var minPossition = i;

                for (int j = i; j < collection.Count; j++)
                {
                    if ((dynamic)collection[j] < (dynamic)min)
                    {
                        minPossition = j;
                    }
                }

                var temp = min;
                collection[i] = collection[minPossition];
                collection[minPossition] = temp;
            }
        }
    }
}
