using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Calculate_RectangleArea
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter Rectangle's width: ");
            float rectangleWidth = float.Parse(Console.ReadLine());
            Console.WriteLine("Please enter Rectangle's height: ");
            float rectangleHeight = float.Parse(Console.ReadLine());
            if (rectangleWidth < 0 || rectangleHeight < 0)
            {
                Console.WriteLine("Please enter valid parameters!!!");
                Main(); 
            }
            Console.WriteLine("The area of the Rectangle is: " + (rectangleHeight * rectangleWidth)); 
        }
    }
}
