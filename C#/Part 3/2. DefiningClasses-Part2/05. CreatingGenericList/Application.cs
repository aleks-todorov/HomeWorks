using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _05.CreatingGenericList.Common;

namespace _05.CreatingGenericList
{
    class Application
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>(5);
            list.AddElement(1);
            list.AddElement(2);
            list.AddElement(3);
            list.AddElement(4);
            list.AddElement(5);

            //Task 5: 
            //list.AddElementAtIndex(3, 10);
            //list.RemoveElementAtIndex(4);
            //list.Clear();

            //Task 6: Showing that if the length of the array is not enough- it expands.
            for (int i = 0; i < 100; i++)
            {
                list.AddElement(i);
            }

            //Task 7: Returning Min and Max Value
            Console.WriteLine(list.Min());
            Console.WriteLine(list.Max());
        }
    }
}
