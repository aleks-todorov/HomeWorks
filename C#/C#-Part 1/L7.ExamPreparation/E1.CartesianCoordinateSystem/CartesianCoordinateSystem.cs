using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _01.CartesianCoordinateSystem
{
    class CartesianCoordinateSystem
    {
        static void Main()
        {
            //string[] numbers = new string[2];
            //numbers[0] = Console.ReadLine().Replace(" ", string.Empty);
            //numbers[1] = Console.ReadLine().Replace(" ", string.Empty);
            //BigInteger valueX = BigInteger.Parse(numbers[0].Replace(" ", string.Empty));
            //BigInteger valueY = BigInteger.Parse(numbers[1].Replace(" ", string.Empty));
            //BigInteger output;
            decimal valueX = decimal.Parse(Console.ReadLine());
            decimal valueY = decimal.Parse(Console.ReadLine());

            if (valueX > 0 && valueY > 0)
            {
                Console.WriteLine(1);
            }
            else if (valueX > 0 && valueY < 0)
            {
                Console.WriteLine(4);
            }
            else if (valueX < 0 && valueY > 0)
            {
                Console.WriteLine(2);
            }
            else if (valueX < 0 && valueY < 0)
            {
                Console.WriteLine(3);
            }
            else if (valueX == 0 && valueY != 0)
            {
                Console.WriteLine(5);
            }
            else if (valueX != 0 && valueY == 0)
            {
                Console.WriteLine(6);
            }
            else if (valueX == 0 && valueY == 0)
            {
                Console.WriteLine(0);
            }

        }
    }
}