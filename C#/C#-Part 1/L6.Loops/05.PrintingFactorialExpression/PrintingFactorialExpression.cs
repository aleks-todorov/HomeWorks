using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.PrintingFactorialExpression
{
    class PrintingFactorialExpression
    {
        static void Main(string[] args)
        {
            //Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).
            decimal N;
            decimal K;
            decimal faktorialN = 1;
            decimal faktorialK = 1;
            decimal faktorialKMinusN = 1;
            do
            {
                Console.Write("N= ");
                N = int.Parse(Console.ReadLine());
                Console.Write("K= ");
                K = int.Parse(Console.ReadLine());
            }
            while (!(K > N && N > 1));

            for (int i = 1; i <= K; i++)
            {
                if (i <= N)
                {
                    faktorialN = faktorialN * i;
                }
                if (i <= (K - N))
                {
                    faktorialKMinusN = faktorialKMinusN * i;
                }
                faktorialK = faktorialK * i;
            }
            decimal result = (faktorialN * faktorialK) / faktorialKMinusN;
            Console.WriteLine("The result is: {0}", result);
        }
    }
}

