using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2.MissCat
{
    class MissCat
    {
        static void Main()
        {
            int valueN = int.Parse(Console.ReadLine());
            int[] cats = new int[10];
            int vote = 0;
            int possition = 1;
            for (int i = 1; i <= valueN; i++)
            {
                vote = int.Parse(Console.ReadLine());
				cats[vote]++; 
            }
            int biggestValue = cats[0];
            for (int i = 0; i < 9; i++)
            {

                if (biggestValue < cats[i + 1])
                {
                    possition = i + 2;
                    biggestValue = cats[i + 1];
                }
            }
            Console.WriteLine(possition);
        }
    }
}
