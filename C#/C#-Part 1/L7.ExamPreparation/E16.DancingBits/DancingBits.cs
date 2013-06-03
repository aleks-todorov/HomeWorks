using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E16.DancingBits
{
    class DancingBits
    {
        //Gives Only 50 points. TO BE FIXED
        static void Main(string[] args)
        {
            int K = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            string bits = "";
            string ones = new string('1', K);
            string zeroes = new string('0', K);
            int count = 0;
            for (int i = 0; i < N; i++)
            {
                int number = int.Parse(Console.ReadLine());
                bits += Convert.ToString(number, 2);
            }
            int index = bits.IndexOf(ones);
            while (index != -1)
            {
                if (index + 3 < bits.Length && bits.Substring(index + 3) != "1")
                {
                    count++;
                }
                index = bits.IndexOf(ones, index + 1);
            }
            index = bits.IndexOf(zeroes);
            while (index != -1)
            {
                if (index + 3 < bits.Length && bits.Substring(index + 3) != "0")
                {
                    count++;
                }
                index = bits.IndexOf(zeroes, index + 1);
            }
            Console.WriteLine(count);
        }
    }
}