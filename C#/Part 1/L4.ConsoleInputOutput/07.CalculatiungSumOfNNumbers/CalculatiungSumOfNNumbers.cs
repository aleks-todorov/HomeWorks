using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.CalculatiungSumOfNNumbers
{
    class CalculatiungSumOfNNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int sum = n;
            int nextNumber; 
            for (int i = 0; i < n; i++)
            {
                nextNumber = int.Parse(Console.ReadLine()); 
                sum += nextNumber; 
            }
            Console.WriteLine("The sum is: " + sum);
        }
    }
}
