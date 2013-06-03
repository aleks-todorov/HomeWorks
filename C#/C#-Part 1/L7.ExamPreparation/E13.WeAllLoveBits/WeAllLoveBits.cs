using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E13.WeAllLoveBits
{
    class WeAllLoveBits
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[] finalNumbers = new int[N];
            for (int i = 0; i < N; i++)
            {
                int P = int.Parse(Console.ReadLine());
                string mirroredP = "";
                while (P > 0)
                {
                    mirroredP += (P % 2).ToString();
                    P /= 2;
                }
                int pMirrored = Convert.ToInt32(mirroredP, 2);
                int mitkoNumber = (P ^ (~P) & pMirrored);
                finalNumbers[i] = mitkoNumber;
            }
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("{0:D}", (int)finalNumbers[i]);
            }
        }
    }
}
