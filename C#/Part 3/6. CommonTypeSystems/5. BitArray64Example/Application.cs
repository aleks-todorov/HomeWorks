using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.BitArray64Example
{
    class Application
    {
        static void Main(string[] args)
        {
            //TODO: fix it so it can work with numbers greater than int.MaxValue
            var numberOne = new BitArray64(int.MaxValue);
            var numberTwo = new BitArray64(int.MaxValue);

            foreach (var bit in numberOne)
            {
                Console.Write(bit);
            }
            Console.WriteLine();

            //Showing Equals
            Compare(numberOne.Equals(numberTwo));
            Compare(numberOne == numberTwo);
            //Will return the opposite of == 
            //Compare(numberOne != numberTwo);

            Console.WriteLine(numberOne.GetHashCode());
        }

        private static void Compare(bool condtion)
        {
            if (condtion)
            {
                Console.WriteLine("Numbers are equal!");
            }
            else
            {
                Console.WriteLine("Numbers are not equal");
            }
        }
    }
}
