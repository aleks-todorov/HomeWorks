namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var value in items)
            {
                if ((dynamic)value == (dynamic)item)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int min = 0;
            int max = items.Count - 1;

            while (max > min)
            {
                int mid = (min + max) / 2;

                if ((dynamic)items[mid] < (dynamic)item)
                {
                    min = mid + 1;
                }

                else if ((dynamic)items[mid] > (dynamic)item)
                {
                    max = mid - 1;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        //Implementing the Knuth Shuffle. Very simple and yet very effective shufling algorithm, with O(n) complexity;
        public void Shuffle()
        {
            Random randomGenerator = new Random();

            for (int i = 0; i < items.Count; i++)
            {
                int rand = randomGenerator.Next(0, i + 1);
                SwapValues(items, i, rand);
            }
        }

        private static void SwapValues(IList<T> collection, int a, int b)
        {
            var temp = collection[a];
            collection[a] = collection[b];
            collection[b] = temp;
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
