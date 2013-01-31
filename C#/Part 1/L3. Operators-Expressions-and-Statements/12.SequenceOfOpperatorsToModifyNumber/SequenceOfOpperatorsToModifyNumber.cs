using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.SequenceOfOpperatorsToModifyNumber
{
    class SequenceOfOpperatorsToModifyNumber
    {
        static void Main(string[] args)
        {
            //We are given integer number n, value v (v= 0 or 1) and a position p. Write a sequence of operators that modifies n to hold 
            //the value v at the position p from the binary representation of n.
            //Example: n = 5 (00000101), p=3, v=1  13 (00001101)
            //n = 5 (00000101), p=2, v=0  1 (00000001)

            Console.WriteLine("Please enter value for n");
            int valueN = int.Parse(Console.ReadLine());
            int mask;
            int changedValueN;
            Console.WriteLine("Please enter possition p:");
            int possitionP = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter vlaue for v (0 or 1)");
            int valueV = int.Parse(Console.ReadLine());
            if (valueV == 1 )
            {
                mask = valueV << possitionP;
                changedValueN = valueN | mask;
                string borderSigns = new string('*', 32);
                PrintResult(valueN, mask, changedValueN);
            }
            else if (valueV == 0)
            {
                mask = ~(1 << possitionP);
                changedValueN = valueN & mask;
                PrintResult(valueN, mask, changedValueN);
            }
            else
            {
                Console.WriteLine("Please enter valid value for v (0 or 1)!");
            }

        }

        private static void PrintResult(int valueN, int mask, int changedValueN)
        {
            string borderSigns = new string('*', 32);
            Console.WriteLine(borderSigns);
            Console.WriteLine(); 
            Console.WriteLine(Convert.ToString(valueN, 2).PadLeft(32, '0'));
            Console.WriteLine(); 
            Console.WriteLine(borderSigns);
            Console.WriteLine(); 
            Console.WriteLine(Convert.ToString(mask, 2).PadLeft(32, '0'));
            Console.WriteLine(); 
            Console.WriteLine(borderSigns);
            Console.WriteLine(); 
            Console.WriteLine(Convert.ToString(changedValueN, 2).PadLeft(32, '0'));
            Console.WriteLine(); 
            Console.WriteLine(borderSigns);
        }
    }
}
