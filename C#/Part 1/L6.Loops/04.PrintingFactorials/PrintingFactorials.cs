using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PrintingFactorials
{
    class PrintingFactorials
    {
        static void Main(string[] args)
        {
            // Write a program that calculates N!/K! for given N and K (1<N<K).
            decimal N; 
            decimal K;
            decimal faktorialN=1;
            decimal faktorialK=1; 
            do
            {
                N = int.Parse(Console.ReadLine());
                K = int.Parse(Console.ReadLine());
            }
            while (!(K > N && N > 1));

            for (int i = 1; i <= K; i++)
            {
                if (i <= N)
                {
                    faktorialN = faktorialN*i;
                }
                faktorialK = faktorialK * i; 
            }
            decimal result = faktorialN / faktorialK;
            Console.WriteLine("The result is: {0}", result);
        }
    }
}
