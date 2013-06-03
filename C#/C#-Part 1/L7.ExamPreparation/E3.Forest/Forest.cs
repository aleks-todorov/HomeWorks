using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3.Forest
{
    class Forest
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string possition = new string('*', 1);
            string street = new string('.', n);
            int counter = 2;
            for (int i = 0; i < 2 * n - 1; i++)
            {
                if (i < n)
                {
                    street = new string('.', i);
                    Console.Write(street);
                    Console.Write(possition);
                    street = new string('.', n - i - 1);
                    Console.WriteLine(street);
                }
                else
                {
                    street = new string('.', n - counter);
                    Console.Write(street);
                    Console.Write(possition);
                    street = new string('.', counter-1);
                    Console.WriteLine(street); 
                    counter++;
                }
            }
        }
    }
}
